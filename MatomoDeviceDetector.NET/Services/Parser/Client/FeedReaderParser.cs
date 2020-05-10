// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedReaderParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Client;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// FeedReaderParser.
    /// </summary>
    public class FeedReaderParser : ClientParserAbstract<List<FeedReader>, ClientMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedReaderParser"/> class.
        /// </summary>
        public FeedReaderParser()
        {
            this.FixtureFile = "regexes/client/feed_readers.yml";
            this.ParserName = "feed reader";
            this.RegexList = this.GetRegexes();
        }
    }
}