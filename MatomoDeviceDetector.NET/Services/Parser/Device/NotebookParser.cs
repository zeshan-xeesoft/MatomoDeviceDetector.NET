// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="NotebookParser.cs" company="Agile Flex Agency">
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
    public class NotebookParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotebookParser"/> class.
        /// </summary>
        public NotebookParser()
        {
            this.FixtureFile = "regexes/device/notebooks.yml";
            this.ParserName = "notebook";
            this.RegexList = this.GetRegexes();
        }
    }
}