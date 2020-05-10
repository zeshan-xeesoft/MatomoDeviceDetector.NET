// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="BotParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services;
    using MatomoDeviceDetectorNET.Services.Results;

    /// <summary>
    /// Class BotParserAbstract
    /// Abstract class for all bot parsers.
    /// </summary>
    public class BotParser : BotParserAbstract<List<Bot>, BotMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BotParser"/> class.
        /// </summary>
        public BotParser()
        {
            this.FixtureFile = "regexes/bots.yml";
            this.ParserName = "bot";
            this.RegexList = this.GetRegexes();
            this.DiscardDetails = true;
        }
    }
}