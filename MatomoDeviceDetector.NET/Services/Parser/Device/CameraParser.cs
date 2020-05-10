// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="CameraParser.cs" company="Agile Flex Agency">
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
    /// CameraParser.
    /// </summary>
    public class CameraParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraParser"/> class.
        /// </summary>
        public CameraParser()
        {
            this.FixtureFile = "regexes/device/cameras.yml";
            this.ParserName = "camera";
            this.RegexList = this.GetRegexes();
        }

        /// <summary>
        /// Parse.
        /// </summary>
        /// <returns>Returns Parse.</returns>
        public override ParseResult<DeviceMatchResult> Parse()
        {
            var result = new ParseResult<DeviceMatchResult>();
            return this.PreMatchOverall() ? base.Parse() : result;
        }
    }
}