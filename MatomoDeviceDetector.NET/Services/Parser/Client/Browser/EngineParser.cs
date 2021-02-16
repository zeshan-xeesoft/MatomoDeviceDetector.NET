// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client.Browser
{
    using System;
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Client;
    using MatomoDeviceDetectorNET.Services.Results;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// Engine Parser.
    /// </summary>
    public class EngineParser : ClientParserAbstract<List<BrowserEngine>, ClientMatchResult>
    {
        /// <summary>
        /// Known browser engines mapped to their internal short codes.
        /// </summary>
        private static string[] availableEngines =
        {
            "WebKit",
            "Blink",
            "Trident",
            "Text-based",
            "Dillo",
            "iCab",
            "Elektra",
            "Presto",
            "Gecko",
            "KHTML",
            "NetFront",
            "Edge",
            "NetSurf",
            "Servo",
            "Goanna",
            "EkiohFlow",
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineParser"/> class.
        /// </summary>
        public EngineParser()
        {
            this.FixtureFile = "regexes/client/browser_engine.yml";
            this.ParserName = "browserengine";
            this.RegexList = this.GetRegexes();
        }

        /// <summary>
        /// Returns list of all available browser engines.
        /// </summary>
        /// <returns>Returns AE.</returns>
        public static string[] GetAvailableEngines()
        {
            return availableEngines;
        }

        /// <summary>
        /// Returns list of all available browser engines.
        /// </summary>
        /// <returns>Returns UA.</returns>
        public override ParseResult<ClientMatchResult> Parse()
        {
            var result = new ParseResult<ClientMatchResult>();
            BrowserEngine localEngine = null;
            string[] localMatches = null;

            foreach (var engine in this.RegexList)
            {
                var matches = this.MatchUserAgent(engine.Regex);

                if (matches.Length <= 0)
                {
                    continue;
                }

                localEngine = engine;
                localMatches = matches;
                break;
            }

            if (localMatches == null)
            {
                return result;
            }

            var name = this.BuildByMatch(localEngine.Name, localMatches);

            foreach (var engineName in availableEngines)
            {
                if (name.ToLower().Equals(engineName.ToLower()))
                {
                    result.Add(new ClientMatchResult { Name = name });
                }
            }

            return result;

            throw new Exception("Detected browser engine was not found in AvailableEngines");
        }
    }
}