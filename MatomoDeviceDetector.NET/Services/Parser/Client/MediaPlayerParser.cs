// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="MediaPlayerParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Client;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// MediaPlayerParser.
    /// </summary>
    public class MediaPlayerParser : ClientParserAbstract<List<MediaPlayer>, ClientMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaPlayerParser"/> class.
        /// </summary>
        public MediaPlayerParser()
        {
            this.FixtureFile = "regexes/client/mediaplayers.yml";
            this.ParserName = "mediaplayer";
            this.RegexList = this.GetRegexes();
        }
    }
}