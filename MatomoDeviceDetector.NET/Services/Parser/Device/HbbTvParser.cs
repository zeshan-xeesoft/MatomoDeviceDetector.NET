// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="HbbTvParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Device
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Device;
    using MatomoDeviceDetectorNET.Services.Results;
    using MatomoDeviceDetectorNET.Services.Results.Device;

    /// <summary>
    /// HbbTvParser.
    /// </summary>
    public class HbbTvParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HbbTvParser"/> class.
        /// </summary>
        public HbbTvParser()
        {
            this.FixtureFile = "regexes/device/televisions.yml";
            this.ParserName = "tv";
            this.RegexList = this.GetRegexes();
        }

        /// <summary>
        /// Parse.
        /// </summary>
        /// <returns>Returns Match.</returns>
        public override ParseResult<DeviceMatchResult> Parse()
        {
            var result = new ParseResult<DeviceMatchResult>();

            if (!this.IsHbbTv())
            {
                return result;
            }

            this.DeviceType = Device.DeviceType.TV;

            result = base.Parse();

            if (!result.Success)
            {
                result.Add(new DeviceMatchResult { Brand = string.Empty, Name = string.Empty, Type = this.DeviceType.Value });
            }

            return result;
        }

        /// <summary>
        /// Is HBB TV.
        /// </summary>
        /// <returns>Bool.</returns>
        public bool IsHbbTv()
        {
            var regex = @"HbbTV/([1-9]{1}(?:\.[0-9]{1}){1,2})";

            return this.IsMatchUserAgent(regex);
        }

        /// <summary>
        /// HBB TV.
        /// </summary>
        /// <returns>Match.</returns>
        public string[] HbbTv()
        {
            var regex = @"HbbTV/([1-9]{1}(?:\.[0-9]{1}){1,2})";

            return this.MatchUserAgent(regex);
        }
    }
}