// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="LibraryParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Client;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// Library Parser.
    /// </summary>
    public class LibraryParser : ClientParserAbstract<List<Library>, ClientMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryParser"/> class.
        /// </summary>
        public LibraryParser()
        {
            this.FixtureFile = "regexes/client/libraries.yml";
            this.ParserName = "library";
            this.RegexList = this.GetRegexes();
        }
    }
}