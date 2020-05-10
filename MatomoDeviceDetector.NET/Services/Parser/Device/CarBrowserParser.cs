// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="CarBrowserParser.cs" company="Agile Flex Agency">
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
    /// CarBrowserParser.
    /// </summary>
    public class CarBrowserParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarBrowserParser"/> class.
        /// </summary>
        public CarBrowserParser()
        {
            this.FixtureFile = "regexes/device/car_browsers.yml";
            this.ParserName = "car browser";
            this.RegexList = this.GetRegexes();
        }

        /// <summary>
        /// Parse.
        /// </summary>
        /// <returns>Returns Pre Match.</returns>
        public override ParseResult<DeviceMatchResult> Parse()
        {
            var result = new ParseResult<DeviceMatchResult>();
            return this.PreMatchOverall() ? base.Parse() : result;
        }
    }
}
