// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceDetector.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MatomoDeviceDetectorNET.Services.Cache;
    using MatomoDeviceDetectorNET.Services.Device;
    using MatomoDeviceDetectorNET.Services.Parser;
    using MatomoDeviceDetectorNET.Services.Parser.Client;
    using MatomoDeviceDetectorNET.Services.Parser.Device;
    using MatomoDeviceDetectorNET.Services.RegexEngine;
    using MatomoDeviceDetectorNET.Services.Results;
    using MatomoDeviceDetectorNET.Services.Results.Client;
    using MatomoDeviceDetectorNET.Services.Results.Device;

    /// <summary>
    /// DeviceDetector.
    /// </summary>
    public class DeviceDetector
    {
        /// <summary>
        /// Current version number of DeviceDetector.
        /// </summary>
        public const string VERSION = "3.12.3";

        /// <summary>
        /// Operating system families that are known as desktop only.
        /// </summary>
        private string[] desktopOsArray =
        {
            "AmigaOS",
            "IBM",
            "GNU/Linux",
            "Mac",
            "Unix",
            "Windows",
            "BeOS",
            "Chrome OS",
        };

        /// <summary>
        /// Constant used as value for unknown browser / os.
        /// </summary>
        public const string UNKNOWN = "UNK";

        /// <summary>
        /// Holds the useragent that should be parsed.
        /// </summary>
        private string userAgent;

        /// <summary>
        /// Holds the operating system data after parsing the UA.
        /// </summary>
        private ParseResult<OsMatchResult> os = new ParseResult<OsMatchResult>();

        /// <summary>
        /// Holds the client data after parsing the UA.
        /// </summary>
        private ParseResult<ClientMatchResult> client = new ParseResult<ClientMatchResult>();

        /// <summary>
        /// Holds the device type after parsing the UA.
        /// </summary>
        private int? device;

        /// <summary>
        /// Holds the device brand data after parsing the UA.
        /// </summary>
        private string brand = string.Empty;

        /// <summary>
        /// Holds the device model data after parsing the UA.
        /// </summary>
        private string model = string.Empty;

        /// <summary>
        /// Holds bot information if parsing the UA results in a bot
        /// (All other information attributes will stay empty in that case)
        ///
        /// If $discardBotInformation is set to true, this property will be set to
        /// true if parsed UA is identified as bot, additional information will be not available
        ///
        /// If $skipBotDetection is set to true, bot detection will not be performed and isBot will
        /// always be false.
        /// </summary>
        private ParseResult<BotMatchResult> bot = new ParseResult<BotMatchResult>();

        private bool discardBotInformation;

        private bool skipBotDetection;

        /// <summary>
        /// Holds the cache class used for caching the parsed yml-Files.
        /// </summary>
        private ICache cache;

        private IRegexEngine regexEngine;

        private List<IClientParserAbstract> clientParsers = new List<IClientParserAbstract>();

        private List<IDeviceParserAbstract> deviceParsers = new List<IDeviceParserAbstract>();

        private List<IBotParserAbstract> botParsers = new List<IBotParserAbstract>();

        private bool parsed;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDetector"/> class.
        /// </summary>
        /// <param name="userAgent">UA.</param>
        public DeviceDetector(string userAgent = "")
        {
            if (!string.IsNullOrEmpty(userAgent))
            {
                this.SetUserAgent(userAgent);
            }

            this.AddStandardClientsParser();
            this.AddStandardDevicesParser();

            this.botParsers.Add(new BotParser());
        }

        /// <summary>
        /// Client Type.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <returns>Bool.</returns>
        public bool Is(ClientType type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the useragent to be parsed.
        /// </summary>
        /// <param name="userAgent">UA.</param>
        public void SetUserAgent(string userAgent)
        {
            if (this.userAgent != userAgent)
            {
                this.Reset();
            }

            this.userAgent = userAgent;
        }

        private void Reset()
        {
            this.bot = new ParseResult<BotMatchResult>();
            this.client = new ParseResult<ClientMatchResult>();
            this.device = null;
            this.os = new ParseResult<OsMatchResult>();
            this.brand = string.Empty;
            this.model = string.Empty;
            this.parsed = false;
        }

        /// <summary>
        /// Add Standard Clients Parser.
        /// </summary>
        public void AddStandardClientsParser()
        {
            this.clientParsers.Add(ClientType.FeedReader.Client);
            this.clientParsers.Add(ClientType.MobileApp.Client);
            this.clientParsers.Add(ClientType.MediaPlayer.Client);
            this.clientParsers.Add(ClientType.PIM.Client);
            this.clientParsers.Add(ClientType.Browser.Client);
            this.clientParsers.Add(ClientType.Library.Client);
        }

        /// <summary>
        /// AddClientParser.
        /// </summary>
        /// <param name="parser">Parser.</param>
        public void AddClientParser(IClientParserAbstract parser)
        {
            this.clientParsers.Add(parser);
        }

        /// <summary>
        /// GetClientsParsers.
        /// </summary>
        /// <returns>List.</returns>
        public IEnumerable<IClientParserAbstract> GetClientsParsers()
        {
            return this.clientParsers.AsEnumerable();
        }

        /// <summary>
        /// Add Standard Devices Parser.
        /// </summary>
        public void AddStandardDevicesParser()
        {
            this.deviceParsers.Add(new HbbTvParser());
            this.deviceParsers.Add(new ConsoleParser());
            this.deviceParsers.Add(new CarBrowserParser());
            this.deviceParsers.Add(new CameraParser());
            this.deviceParsers.Add(new PortableMediaPlayerParser());
            this.deviceParsers.Add(new MobileParser());
        }

        /// <summary>
        /// AddDeviceParser.
        /// </summary>
        /// <param name="parser">Parser.</param>
        public void AddDeviceParser(IDeviceParserAbstract parser)
        {
            this.deviceParsers.Add(parser);
        }

        /// <summary>
        /// GetDeviceParsers.
        /// </summary>
        /// <returns>List.</returns>
        public IEnumerable<IDeviceParserAbstract> GetDeviceParsers()
        {
            return this.deviceParsers.AsEnumerable();
        }

        /// <summary>
        /// Sets whether to discard additional bot information
        /// If information is discarded it's only possible check whether UA was detected as bot or not.
        /// (Discarding information speeds up the detection a bit).
        /// </summary>
        /// <param name="discard">Discard.</param>
        public void DiscardBotInformation(bool discard = true)
        {
            this.discardBotInformation = discard;
        }

        /// <summary>
        /// Sets whether to skip bot detection.
        /// It is needed if we want bots to be processed as a simple clients. So we can detect if it is mobile client,
        /// or desktop, or enything else. By default all this information is not retrieved for the bots.
        /// </summary>
        /// <param name="skip">Skip.</param>
        public void SkipBotDetection(bool skip = true)
        {
            this.skipBotDetection = skip;
        }

        /// <summary>
        /// Returns if the parsed UA was identified as a Bot
        /// @see bots.yml for a list of detected bots.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool IsBot()
        {
            return this.bot.Success;
        }

        /// <summary>
        /// Returns if the parsed UA was identified as a touch enabled device
        /// Note: That only applies to windows 8 tablets.
        /// </summary>
        /// <returns>Is Match.</returns>
        public bool IsTouchEnabled()
        {
            const string regex = "Touch";
            return this.IsMatchUserAgent(regex);
        }

        /// <summary>
        /// Returns if the parsed UA contains the 'Android; Tablet;' fragment.
        /// </summary>
        /// <returns>Regex.</returns>
        public bool HasAndroidTableFragment()
        {
            const string regex = @"Android( [\.0-9]+)?; Tablet;";
            return this.IsMatchUserAgent(regex);
        }

        /// <summary>
        /// Returns if the parsed UA contains the 'Android; Mobile;' fragment.
        /// </summary>
        /// <returns>Match.</returns>
        public bool HasAndroidMobileFragment()
        {
            const string regex = @"Android( [\.0-9]+)?; Mobile;";
            return this.IsMatchUserAgent(regex);
        }

        private bool UsesMobileBrowser()
        {
            if (!this.client.Success)
            {
                return false;
            }

            var match = this.client.Match;

            return match.Type == ClientType.Browser.Name && BrowserParser.IsMobileOnlyBrowser(((BrowserMatchResult)match).ShortName);
        }

        /// <summary>
        /// Is Tablet.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool IsTablet()
        {
            return this.device.HasValue && this.device.Value == DeviceType.TABLET;
        }

        /// <summary>
        /// Is Mobile.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool IsMobile()
        {
            var mobileDeviceTypes = new List<int>
            {
                DeviceType.FEATUREPHONE,
                DeviceType.SMARTPHONE,
                DeviceType.TABLET,
                DeviceType.PHABLET,
                DeviceType.CAMERA,
                DeviceType.PORTABLEMEDIAPLAYER,
            };

            if (this.device.HasValue && mobileDeviceTypes.Contains(this.device.Value))
            {
                return true;
            }

            var nonMobileDeviceTypes = new List<int>
            {
                DeviceType.TV,
                DeviceType.SMARTDISPLAY,
                DeviceType.CONSOLE,
            };

            if (this.device.HasValue && nonMobileDeviceTypes.Contains(this.device.Value))
            {
                return false;
            }

            if (this.UsesMobileBrowser())
            {
                return true;
            }

            var osShort = this.os.Success ? this.os.Match.ShortName : string.Empty;

            if (string.IsNullOrEmpty(osShort) || osShort == UNKNOWN)
            {
                return false;
            }

            return !this.IsBot() && !this.IsDesktop();
        }

        /// <summary>
        /// Returns if the parsed UA was identified as desktop device
        /// Desktop devices are all devices with an unknown type that are running a desktop os.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool IsDesktop()
        {
            var osShort = this.os.Success ? this.os.Match.ShortName : string.Empty;

            if (string.IsNullOrEmpty(osShort) || osShort == UNKNOWN)
            {
                return false;
            }

            if (this.UsesMobileBrowser())
            {
                return false;
            }

            OperatingSystemParser.GetOsFamily(osShort, out string decodedFamily);

            return Array.IndexOf(this.desktopOsArray, decodedFamily) > -1;
        }

        /// <summary>
        /// Returns the operating system data extracted from the parsed UA
        /// If $attr is given only that property will be returned.
        /// </summary>
        /// <returns>OS.</returns>
        public ParseResult<OsMatchResult> GetOs()
        {
            if (!this.os.Success)
            {
                return new ParseResult<OsMatchResult>(new UnknownOsMatchResult(), false);
            }

            return this.os;
        }

        /// <summary>
        /// Get Client.
        /// </summary>
        /// <returns>Client.</returns>
        public ParseResult<ClientMatchResult> GetClient()
        {
            if (!this.client.Success)
            {
                return new ParseResult<ClientMatchResult>(new UnknownClientMatchResult(), false);
            }

            return this.client;
        }

        /// <summary>
        /// Get browser client.
        /// </summary>
        /// <returns>Browser.</returns>
        public ParseResult<BrowserMatchResult> GetBrowserClient()
        {
            if (this.client.Success)
            {
                if (this.client.Match is BrowserMatchResult browser)
                {
                    return new ParseResult<BrowserMatchResult>(browser);
                }
            }

            return new ParseResult<BrowserMatchResult>();
        }

        /// <summary>
        /// Returns the device type extracted from the parsed UA
        ///  <see cref="DeviceParserAbstract{T,TResult}.DeviceTypes"/> for available device types.
        /// </summary>
        /// <returns>Device.</returns>
        public string GetDeviceName()
        {
            return this.device.HasValue ? DeviceParserAbstract<Dictionary<string, DeviceModel>, DeviceMatchResult>.GetDeviceName(this.device.Value).Key : null;
        }

        /// <summary>
        /// Get Brand.
        /// </summary>
        /// <returns>Brand.</returns>
        public string GetBrand()
        {
            return this.brand;
        }

        /// <summary>
        /// Returns the full device brand name extracted from the parsed UA
        /// @see self::$deviceBrand for available device brands.
        /// </summary>
        /// <returns>Returns BrandName.</returns>
        public string GetBrandName()
        {
            return DeviceParserAbstract<Dictionary<string, DeviceModel>, DeviceMatchResult>.GetFullName(this.brand);
        }

        /// <summary>
        /// Get the Model.
        /// </summary>
        /// <returns>Model.</returns>
        public string GetModel()
        {
            return this.model;
        }

        /// <summary>
        /// Returns the bot extracted from the parsed UA.
        /// </summary>
        /// <returns>Bot.</returns>
        public ParseResult<BotMatchResult> GetBot()
        {
            return this.bot;
        }

        /// <summary>
        /// Returns true, if userAgent was already parsed with <see cref="Parse"/>.
        /// </summary>
        /// <returns>Parsed.</returns>
        public bool IsParsed()
        {
            return this.parsed;
        }

        /// <summary>
        /// Triggers the parsing of the current user agent.
        /// </summary>
        public void Parse()
        {
            if (this.IsParsed())
            {
                return;
            }

            this.parsed = true;

            if (string.IsNullOrEmpty(this.userAgent) || !this.GetRegexEngine().Match(this.userAgent, "([a-z])"))
            {
                return;
            }

            this.ParseBot();

            if (this.IsBot())
            {
                return;
            }

            this.ParseOs();
            this.ParseClient();
            this.ParseDevice();
        }

        /// <summary>
        /// Parses the UA for bot information using the Bot parser.
        /// </summary>
        private void ParseBot()
        {
            if (this.skipBotDetection)
            {
                this.bot = new ParseResult<BotMatchResult>();
                return;
            }

            foreach (var botParser in this.botParsers)
            {
                var parser = (BotParser)botParser;

                parser.SetUserAgent(this.userAgent);
                parser.SetCache(this.cache);
                parser.DiscardDetails = this.discardBotInformation;
                var botParseResult = parser.Parse();

                if (!botParseResult.Success)
                {
                    continue;
                }

                this.bot = botParseResult;
                return;
            }
        }

        /// <summary>
        /// Parse Client.
        /// </summary>
        protected void ParseClient()
        {
            foreach (var clientParser in this.clientParsers)
            {
                clientParser.SetCache(this.cache);
                clientParser.SetUserAgent(this.userAgent);

                if (clientParser.ParserName == ClientType.FeedReader.Name)
                {
                    var parser = (FeedReaderParser)clientParser;
                    var result = parser.Parse();

                    if (result.Success)
                    {
                        this.client = new ParseResult<ClientMatchResult>();
                        this.client.AddRange(result.Matches);
                        return;
                    }
                }

                if (clientParser.ParserName == ClientType.MobileApp.Name)
                {
                    var parser = (MobileAppParser)clientParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.client = new ParseResult<ClientMatchResult>();
                        this.client.AddRange(result.Matches);
                        return;
                    }
                }

                if (clientParser.ParserName == ClientType.MediaPlayer.Name)
                {
                    var parser = (MediaPlayerParser)clientParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.client = new ParseResult<ClientMatchResult>();
                        this.client.AddRange(result.Matches);
                        return;
                    }
                }

                if (clientParser.ParserName == ClientType.PIM.Name)
                {
                    var parser = (PimParser)clientParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.client = new ParseResult<ClientMatchResult>();
                        this.client.AddRange(result.Matches);
                        return;
                    }
                }

                if (clientParser.ParserName == ClientType.Library.Name)
                {
                    var parser = (LibraryParser)clientParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.client = new ParseResult<ClientMatchResult>();
                        this.client.AddRange(result.Matches);
                        return;
                    }
                }

                if (clientParser.ParserName == ClientType.Browser.Name)
                {
                    var parser = (BrowserParser)clientParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.client = new ParseResult<ClientMatchResult>();
                        this.client.AddRange(result.Matches);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Parse Device.
        /// </summary>
        protected void ParseDevice()
        {
            foreach (var deviceParser in this.deviceParsers)
            {
                deviceParser.SetCache(this.cache);
                deviceParser.SetUserAgent(this.userAgent);

                if (deviceParser.ParserName == "tv")
                {
                    var parser = (HbbTvParser)deviceParser;

                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.device = result.Match.Type;
                        this.model = result.Match.Name;
                        this.brand = result.Match.Brand;
                        break;
                    }
                }

                if (deviceParser.ParserName == "consoles")
                {
                    var parser = (ConsoleParser)deviceParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.device = result.Match.Type;
                        this.model = result.Match.Name;
                        this.brand = result.Match.Brand;
                        break;
                    }
                }

                if (deviceParser.ParserName == "car browser")
                {
                    var parser = (CarBrowserParser)deviceParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.device = result.Match.Type;
                        this.model = result.Match.Name;
                        this.brand = result.Match.Brand;
                        break;
                    }
                }

                if (deviceParser.ParserName == "camera")
                {
                    var parser = (CameraParser)deviceParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.device = result.Match.Type;
                        this.model = result.Match.Name;
                        this.brand = result.Match.Brand;
                        break;
                    }
                }

                if (deviceParser.ParserName == "portablemediaplayer")
                {
                    var parser = (PortableMediaPlayerParser)deviceParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.device = result.Match.Type;
                        this.model = result.Match.Name;
                        this.brand = result.Match.Brand;
                        break;
                    }
                }

                if (deviceParser.ParserName == "mobiles")
                {
                    var parser = (MobileParser)deviceParser;
                    var result = parser.Parse();
                    if (result.Success)
                    {
                        this.device = result.Match.Type;
                        this.model = result.Match.Name;
                        this.brand = result.Match.Brand;
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(this.brand))
            {
                var vendorParser = new VendorFragmentParser();
                vendorParser.SetUserAgent(this.userAgent);
                vendorParser.SetCache(this.cache);
                var result = vendorParser.Parse();
                if (result.Success)
                {
                    this.brand = result.Match.Brand;
                }
            }

            this.os = this.GetOs();

            var osShortName = string.Empty;
            var osFamily = string.Empty;
            var osVersion = string.Empty;
            if (this.os.Success)
            {
                osShortName = this.os.Match.ShortName;
                OperatingSystemParser.GetOsFamily(osShortName, out osFamily);
                osVersion = this.os.Match.Version;
                if (!string.IsNullOrEmpty(osVersion))
                {
                    osVersion = !osVersion.Contains(".") ? osVersion + ".0" : osVersion;
                }
            }

            this.client = this.GetClient();
            var clientName = this.client.Success ? this.client.Match.Name : string.Empty;

            if (string.IsNullOrEmpty(this.brand) && new[] { "ATV", "IOS", "MAC" }.Contains(osShortName))
            {
                this.brand = "AP";
            }

            if (!this.device.HasValue && osFamily == "Android" && (clientName == "Chrome" || clientName == "Chrome Mobile"))
            {
                if (this.IsMatchUserAgent(@"Chrome/[\.0-9]* Mobile"))
                {
                    this.device = DeviceType.SMARTPHONE;
                }
                else if (this.IsMatchUserAgent(@"Chrome/[\.0-9]* (?!Mobile)"))
                {
                    this.device = DeviceType.TABLET;
                }
            }

            if (!this.device.HasValue && (this.HasAndroidTableFragment() || this.IsMatchUserAgent("Opera Tablet")))
            {
                this.device = DeviceType.TABLET;
            }

            if (!this.device.HasValue && this.HasAndroidMobileFragment())
            {
                this.device = DeviceType.SMARTPHONE;
            }

            if (!this.device.HasValue && osShortName == "AND" && osVersion != string.Empty)
            {
                if (System.Version.TryParse(osVersion, out _) && new System.Version(osVersion).CompareTo(new System.Version("2.0")) == -1)
                {
                    this.device = DeviceType.SMARTPHONE;
                }
                else if (System.Version.TryParse(osVersion, out _) && new System.Version(osVersion).CompareTo(new System.Version("3.0")) >= 0 && new System.Version(osVersion).CompareTo(new System.Version("4.0")) == -1)
                {
                    this.device = DeviceType.TABLET;
                }
            }

            if (this.device == DeviceType.FEATUREPHONE && osFamily == "Android")
            {
                this.device = DeviceType.SMARTPHONE;
            }

            if (!this.device.HasValue && (osShortName == "WRT" || (osShortName == "WIN" && System.Version.TryParse(osVersion, out _) && new System.Version(osVersion).CompareTo(new System.Version("8.0")) >= 0)) && this.IsTouchEnabled())
            {
                this.device = DeviceType.TABLET;
            }

            if (this.IsMatchUserAgent("Opera TV Store"))
            {
                this.device = DeviceType.TV;
            }

            if (!this.device.HasValue && (clientName == "Kylo" || clientName == "Espial TV Browser"))
            {
                this.device = DeviceType.TV;
            }

            if (!this.device.HasValue && this.IsDesktop())
            {
                this.device = DeviceType.DESKTOP;
            }
        }

        private void ParseOs()
        {
            var osParser = new OperatingSystemParser();
            osParser.SetUserAgent(this.userAgent);
            osParser.SetCache(this.cache);

            this.os = osParser.Parse();
        }

        /// <summary>
        /// Parses a useragent and returns the detected data
        ///
        /// ATTENTION: Use that method only for testing or very small applications
        /// To get fast results from DeviceDetector you need to make your own implementation,
        /// that should use one of the caching mechanisms. See README.md for more information.
        ///
        /// </summary>
        /// <param name="ua">UserAgent to parse.</param>
        /// <returns>Match.</returns>
        public static ParseResult<DeviceDetectorResult> GetInfoFromUserAgent(string ua)
        {
            var result = new ParseResult<DeviceDetectorResult>();
            var deviceDetector = new DeviceDetector(ua);

            deviceDetector.Parse();

            var match = new DeviceDetectorResult { UserAgent = deviceDetector.userAgent };

            if (deviceDetector.IsBot())
            {
                match.Bot = deviceDetector.bot.Match;
            }

            match.Os = deviceDetector.os.Match;
            match.Client = deviceDetector.client.Match;
            match.DeviceType = deviceDetector.GetDeviceName();
            match.DeviceBrand = deviceDetector.brand;
            match.DeviceModel = deviceDetector.model;

            if (deviceDetector.os.Success)
            {
                OperatingSystemParser.GetOsFamily(deviceDetector.os.Match.ShortName, out var osFamily);
                match.OsFamily = osFamily;
            }

            if (!(deviceDetector.client.Match is BrowserMatchResult browserMatch))
            {
                return result.Add(match);
            }

            BrowserParser.GetBrowserFamily(browserMatch.ShortName, out var browserFamily);
            match.BrowserFamily = browserFamily;
            return result.Add(match);
        }

        /// <summary>
        /// Sets the Cache.
        /// </summary>
        /// <param name="cache">Cache.</param>
        public void SetCache(ICache cache)
        {
            this.cache = cache;
        }

        /// <summary>
        /// Get Cache.
        /// </summary>
        /// <returns>Cache.</returns>
        public ICache GetCache()
        {
            return this.cache ?? new Cache();
        }

        /// <summary>
        /// Set Regex Engine.
        /// </summary>
        /// <param name="regexEng">Regex.</param>
        public void SetRegexEngine(IRegexEngine regexEng)
        {
            this.regexEngine = regexEng ?? throw new ArgumentNullException(nameof(regexEng));
        }

        /// <summary>
        /// Get Regex Engine.
        /// </summary>
        /// <returns>Engine.</returns>
        public IRegexEngine GetRegexEngine()
        {
            return this.regexEngine ?? new MsRegexEngine();
        }

        /// <summary>
        /// Is Match UA.
        /// </summary>
        /// <param name="regex">Regex.</param>
        /// <returns>Match.</returns>
        private bool IsMatchUserAgent(string regex)
        {
            // only match if useragent begins with given regex or there is no letter before it
            var match = this.GetRegexEngine().Match(this.userAgent, FixUserAgentRegEx(regex));
            return match;
        }

        /// <summary>
        /// Match UA.
        /// </summary>
        /// <param name="regex">Regex.</param>
        /// <returns>Match.</returns>
        protected string[] MatchUserAgent(string regex)
        {
            // only match if useragent begins with given regex or there is no letter before it
            var match = this.regexEngine.Matches(this.userAgent, FixUserAgentRegEx(regex));
            return match.ToArray();
        }

        /// <summary>
        /// Fix UA.
        /// </summary>
        /// <param name="regex">Regex.</param>
        /// <returns>Fixed UA.</returns>
        private static string FixUserAgentRegEx(string regex)
        {
            return @"(?:^|[^A-Z_-])(?:" + regex.Replace("/", @"\/").Replace("++", "+") + ")";
        }

        /// <summary>
        /// Set Version Truncation.
        /// </summary>
        /// <param name="versionTruncation">Truncation.</param>
        public static void SetVersionTruncation(int versionTruncation)
        {
            ParserAbstract<List<Services.Bot>, BotMatchResult>.SetVersionTruncation(versionTruncation);
            ParserAbstract<List<Services.Os>, OsMatchResult>.SetVersionTruncation(versionTruncation);
            ParserAbstract<Dictionary<string, string[]>, VendorFragmentResult>.SetVersionTruncation(versionTruncation);

            ParserAbstract<List<Services.Client.FeedReader>, ClientMatchResult>.SetVersionTruncation(versionTruncation);
            ParserAbstract<List<Services.Client.MobileApp>, ClientMatchResult>.SetVersionTruncation(versionTruncation);
            ParserAbstract<List<Services.Client.MediaPlayer>, ClientMatchResult>.SetVersionTruncation(versionTruncation);
            ParserAbstract<List<Services.Client.Pim>, ClientMatchResult>.SetVersionTruncation(versionTruncation);
            ParserAbstract<List<Services.Client.Browser>, BrowserMatchResult>.SetVersionTruncation(versionTruncation);
            ParserAbstract<List<Services.Client.Library>, ClientMatchResult>.SetVersionTruncation(versionTruncation);

            ParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>.SetVersionTruncation(versionTruncation);
        }
    }
}
