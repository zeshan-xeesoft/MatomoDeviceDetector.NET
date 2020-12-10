// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client.Browser.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using MatomoDeviceDetectorNET.Services.Client;
    using MatomoDeviceDetectorNET.Services.Results;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// Version Parser.
    /// </summary>
    public class VersionParser : ClientParserAbstract<List<IClientParseLibrary>, ClientMatchResult>
    {
        private readonly string engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionParser"/> class.
        /// </summary>
        /// <param name="ua">The User Agent.</param>
        /// <param name="engine">The Engine.</param>
        public VersionParser(string ua, string engine)
            : base(ua)
        {
            this.engine = engine;
        }

        /// <summary>
        /// Gets the Parse.
        /// </summary>
        /// <returns>Returns Match on Parse.</returns>
        public override ParseResult<ClientMatchResult> Parse()
        {
            var result = new ParseResult<ClientMatchResult>();

            if (string.IsNullOrEmpty(this.engine))
            {
                return result;
            }

            var matches = this.GetRegexEngine().MatchesUnique(this.UserAgent, this.engine + @"\s*\/?\s*((?(?=\d+\.\d)\d+[.\d]*|\d{1,8}(?=(?:\D|$))))").ToArray();

            if (matches.Length <= 0)
            {
                return result;
            }

            foreach (var match in matches)
            {
                result.Add(new ClientMatchResult { Name = match });
            }

            return result;
        }
    }
}