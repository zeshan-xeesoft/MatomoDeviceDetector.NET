// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParserAbstract.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using MatomoDeviceDetectorNET.Services;
    using MatomoDeviceDetectorNET.Services.Cache;
    using MatomoDeviceDetectorNET.Services.Device;
    using MatomoDeviceDetectorNET.Services.RegexEngine;
    using MatomoDeviceDetectorNET.Services.Results;
    using MatomoDeviceDetectorNET.Services.Yaml;

    /// <summary>
    /// ParserAbstract.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    /// <typeparam name="TResult">TResult.</typeparam>
    public abstract class ParserAbstract<T, TResult> : IParserAbstract
        where T : class, IEnumerable
        where TResult : class, IMatchResult, new()
    {
        /// <summary>
        /// Gets or sets holds the path to the yml file containing regexes.
        /// </summary>
        public string FixtureFile { get; protected set; }

        /// <summary>
        /// Gets or sets holds the internal name of the parser
        /// Used for caching.
        /// </summary>
        public string ParserName { get; protected set; }

        /// <summary>
        /// Gets holds the user agent the should be parsed.
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// Holds an array with regexes to parse, if already loaded.
        /// </summary>
        public T RegexList;

        /// <summary>
        /// Indicates how deep versioning will be detected
        /// if $maxMinorParts is 0 only the major version will be returned.
        /// </summary>
        private static int maxMinorParts = -1;

        /// <summary>
        /// Versioning constant used to set max versioning to major version only
        /// Version examples are: 3, 5, 6, 200, 123, ...
        /// </summary>
        public const int VERSIONTRUNCATIONMAJOR = 0;

        /// <summary>
        /// Versioning constant used to set max versioning to minor version
        /// Version examples are: 3.4, 5.6, 6.234, 0.200, 1.23, ...
        /// </summary>
        public const int VERSIONTRUNCATIONMINOR = 1;

        /// <summary>
        /// Versioning constant used to set max versioning to path level
        /// Version examples are: 3.4.0, 5.6.344, 6.234.2, 0.200.3, 1.2.3, ...
        /// </summary>
        public const int VERSIONTRUNCATIONPATCH = 2;

        /// <summary>
        /// Versioning constant used to set versioning to build number
        /// Version examples are: 3.4.0.12, 5.6.334.0, 6.234.2.3, 0.200.3.1, 1.2.3.0, ...
        /// </summary>
        public const int VERSIONTRUNCATIONBUILD = 3;

        /// <summary>
        /// Versioning constant used to set versioning to unlimited (no truncation).
        /// </summary>
        public const int VERSIONTRUNCATIONNONE = -1;

        /// <summary>
        /// Gets the Cache.
        /// </summary>
        private ICache cache;

        /// <summary>
        /// Gets the Parser.
        /// </summary>
        private IParser<T> yamlParser;

        /// <summary>
        /// Gets the Regex.
        /// </summary>
        private IRegexEngine regexEngine;

        /// <summary>
        /// Parse.
        /// </summary>
        /// <returns>Ex.</returns>
        public virtual ParseResult<TResult> Parse()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserAbstract{T, TResult}"/> class.
        /// </summary>
        protected ParserAbstract()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserAbstract{T, TResult}"/> class.
        /// </summary>
        /// <param name="ua">UA.</param>
        protected ParserAbstract(string ua = "")
        {
            if (string.IsNullOrEmpty(ua))
            {
                throw new ArgumentNullException(nameof(ua));
            }

            this.UserAgent = ua;
        }

        /// <summary>
        /// Set how DeviceDetector should return versions.
        /// </summary>
        /// <param name="type">Any of the VERSION_TRUNCATION_* constants.</param>
        public static void SetVersionTruncation(int type)
        {
            var versions = new List<int>
            {
                VERSIONTRUNCATIONBUILD,
                VERSIONTRUNCATIONNONE,
                VERSIONTRUNCATIONMAJOR,
                VERSIONTRUNCATIONMINOR,
                VERSIONTRUNCATIONPATCH,
            };

            if (versions.Contains(type))
            {
                maxMinorParts = type;
            }
        }

        /// <summary>
        /// Sets the user agent to parse.
        /// </summary>
        /// <param name="ua">UA.</param>
        public virtual void SetUserAgent(string ua)
        {
            if (string.IsNullOrEmpty(ua))
            {
                throw new ArgumentNullException(nameof(ua));
            }

            this.UserAgent = ua;
        }

        /// <summary>
        /// Returns the internal name of the parser.
        /// </summary>
        /// <returns>Parser Name.</returns>
        public string GetName()
        {
            return this.ParserName;
        }

        /// <summary>
        /// Returns the result of the parsed yml file defined in $fixtureFile.
        /// </summary>
        /// <returns>Match.</returns>
        protected T GetRegexes()
        {
            if (this.RegexList.Any())
            {
                return this.RegexList;
            }

            var cacheKey = "DeviceDetector-" + DeviceDetector.VERSION + "regexes-" + this.GetName();

            cacheKey = this.GetRegexEngine().Replace(cacheKey, "/([^a-z0-9_-]+)/i", string.Empty);

            var regexListCache = this.GetCache().Fetch(cacheKey);

            if (regexListCache != null)
            {
                this.RegexList = (T)regexListCache;
            }

            if (this.RegexList.Any())
            {
                return this.RegexList;
            }

            var regexesDir = this.GetRegexesDirectory();

            if (regexesDir == string.Empty)
            {
                var assembly = typeof(DeviceDetector).GetTypeInfo().Assembly;
                var filePath = this.FixtureFile.Replace("/", ".");
                var fullPath = $"{nameof(MatomoDeviceDetectorNET)}.{filePath}";

                using (Stream resource = assembly.GetManifestResourceStream(fullPath))
                {
                    this.RegexList = this.GetYamlParser().ParseStream(resource);
                }
            }
            else
            {
                this.RegexList = this.GetYamlParser().ParseFile(regexesDir + this.FixtureFile);
            }

            this.GetCache().Save(cacheKey, this.RegexList);

            return this.RegexList;
        }

        /// <summary>
        /// Get Regexes Directory.
        /// </summary>
        /// <returns>Dir.</returns>
        protected string GetRegexesDirectory()
        {
            return Settings.RegexesDirectory;
        }

        /// <summary>
        /// Matches the useragent against the given regex.
        /// </summary>
        /// <param name="regex">Regex.</param>
        /// <returns>Match.</returns>
        protected bool IsMatchUserAgent(string regex)
        {
            return this.GetRegexEngine().Match(this.UserAgent, this.FixUserAgentRegEx(regex));
        }

        /// <summary>
        /// MatchUserAgent.
        /// </summary>
        /// <param name="regex">Regex.</param>
        /// <returns>Array.</returns>
        protected string[] MatchUserAgent(string regex)
        {
            return this.GetRegexEngine().Matches(this.UserAgent, this.FixUserAgentRegEx(regex)).ToArray();
        }

        /// <summary>
        /// Fix User Agent Reg Ex.
        /// </summary>
        /// <param name="regex">Regex.</param>
        /// <returns>Fixed.</returns>
        private string FixUserAgentRegEx(string regex)
        {
            return @"(?:^|[^A-Z0-9\-_]|[^A-Z0-9\-]_|sprd-)(?:" + regex.Replace("/", @"\/").Replace("++", "+").Replace(@"\_", "_") + ")";
        }

        /// <summary>
        /// Build By Match.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="matches">Matches.</param>
        /// <returns>String.</returns>
        protected string BuildByMatch(string item, string[] matches)
        {
            for (var nb = 1; nb <= 3; nb++)
            {
                if (!item.Contains("$" + nb))
                {
                    continue;
                }

                var replace = matches[nb] ?? string.Empty;
                item = item.Replace("$" + nb, replace).Trim();
            }

            return item;
        }

        /// <summary>
        /// Builds the version with the given $versionString and $matches
        /// Example:
        /// $versionString = 'v$2'
        /// $matches = array('version_1_0_1', '1_0_1')
        /// return value would be v1.0.1.
        /// </summary>
        /// <param name="versionString">Version.</param>
        /// <param name="matches">Matches.</param>
        /// <returns>String.</returns>
        protected string BuildVersion(string versionString, string[] matches)
        {
            versionString = this.BuildByMatch(versionString ?? string.Empty, matches);
            versionString = versionString.Replace("_", ".").TrimEnd('.');

            var versionParts = versionString.Split('.');

            if (maxMinorParts == -1 || versionParts.Length - 1 <= maxMinorParts)
            {
                return versionString;
            }

            var newVersionParts = new string[1 + maxMinorParts];
            Array.Copy(versionParts, 0, newVersionParts, 0, newVersionParts.Length);
            versionString = string.Join(".", newVersionParts);

            return versionString;
        }

        /// <summary>
        /// Tests the useragent against a combination of all regexes
        ///
        /// All regexes returned by getRegexes() will be reversed and concated with '|'
        /// Afterwards the big regex will be tested against the user agent
        ///
        /// Method can be used to speed up detections by making a big check before doing checks for every single regex.
        /// </summary>
        /// <returns>Bool.</returns>
        protected bool PreMatchOverall()
        {
            var regexes = this.GetRegexes();

            var cacheKey = this.ParserName + DeviceDetector.VERSION + "-all";

            cacheKey = this.GetRegexEngine().Replace(cacheKey, "/([^a-z0-9_-]+)/i", string.Empty);

            var regexListCache = this.GetCache().Fetch(cacheKey);
            string overAllMatch = regexListCache?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(overAllMatch))
            {
                List<IParseLibrary> parses = new List<IParseLibrary>();

                if (regexes is IDictionary)
                {
                    var devices = regexes.Cast<KeyValuePair<string, DeviceModel>>().Select(d => d.Value).ToList();
                    parses.AddRange(devices.OfType<IParseLibrary>());
                    var models = devices.Where(e => e.Models != null).SelectMany(m => m.Models);
                    parses.AddRange(models.OfType<IParseLibrary>());
                }
                else
                {
                    parses = regexes.OfType<IParseLibrary>().ToList();
                }

                if (parses.Any())
                {
                    parses.Reverse();

                    overAllMatch = string.Join("|", parses.Where(p => !string.IsNullOrEmpty(p.Regex)).Select(r => r.Regex));
                }

                this.GetCache().Save(cacheKey, overAllMatch);
            }

            return this.IsMatchUserAgent(overAllMatch);
        }

        /// <summary>
        /// Sets the Cache class.
        /// </summary>
        /// <param name="cacheProvider">CP.</param>
        public void SetCache(ICache cacheProvider)
        {
            this.cache = cacheProvider;
        }

        /// <summary>
        /// Returns Cache object.
        /// </summary>
        /// <returns>Cache.</returns>
        public ICache GetCache()
        {
            if (this.cache != null)
            {
                return this.cache;
            }

            this.cache = new Cache();

            return this.cache;
        }

        /// <summary>
        /// SetYamlParser.
        /// </summary>
        /// <param name="yaml">Yaml.</param>
        public void SetYamlParser(IParser<T> yaml)
        {
            if (!(yaml is YamlParser<T>))
            {
                throw new Exception("Yaml Parser not supported");
            }

            this.yamlParser = yaml;
        }

        /// <summary>
        /// Get Yaml Parser.
        /// </summary>
        /// <returns>Yaml.</returns>
        public IParser<T> GetYamlParser()
        {
            return this.yamlParser ?? new YamlParser<T>();
        }

        /// <summary>
        /// SetRegexEngine.
        /// </summary>
        /// <param name="regexEngine">Regex.</param>
        public void SetRegexEngine(IRegexEngine regexEngine)
        {
            this.regexEngine = regexEngine ?? throw new ArgumentNullException(nameof(regexEngine));
        }

        /// <summary>
        /// GetRegexEngine.
        /// </summary>
        /// <returns>Regex.</returns>
        public IRegexEngine GetRegexEngine()
        {
            return this.regexEngine ?? new MsRegexEngine();
        }
    }
}