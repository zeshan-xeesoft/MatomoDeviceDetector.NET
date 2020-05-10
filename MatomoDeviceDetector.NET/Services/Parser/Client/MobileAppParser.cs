// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="MobileAppParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Client;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// MobileAppParser.
    /// </summary>
    public class MobileAppParser : ClientParserAbstract<List<MobileApp>, ClientMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileAppParser"/> class.
        /// </summary>
        public MobileAppParser()
        {
            this.FixtureFile = "regexes/client/mobile_apps.yml";
            this.ParserName = "mobile app";
            this.RegexList = this.GetRegexes();
        }
    }
}