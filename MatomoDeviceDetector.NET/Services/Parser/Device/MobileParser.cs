// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="MobileParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Device
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Device;
    using MatomoDeviceDetectorNET.Services.Results.Device;

    /// <summary>
    /// MobileParser.
    /// </summary>
    public class MobileParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileParser"/> class.
        /// </summary>
        public MobileParser()
        {
            this.FixtureFile = "regexes/device/mobiles.yml";
            this.ParserName = "mobiles";
            this.RegexList = this.GetRegexes();
        }
    }
}