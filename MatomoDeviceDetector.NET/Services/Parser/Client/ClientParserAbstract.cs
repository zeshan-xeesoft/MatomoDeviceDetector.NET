// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientParserAbstract.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using MatomoDeviceDetectorNET.Services.Client;
    using MatomoDeviceDetectorNET.Services.Results;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// Client Parser.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    /// <typeparam name="TResult">T Result.</typeparam>
    public abstract class ClientParserAbstract<T, TResult> : ParserAbstract<T, TResult>, IClientParserAbstract
        where T : class, IEnumerable<IClientParseLibrary>
        where TResult : class, IClientMatchResult, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientParserAbstract{T, TResult}"/> class.
        /// </summary>
        protected ClientParserAbstract()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientParserAbstract{T, TResult}"/> class.
        /// </summary>
        /// <param name="ua">The UA.</param>
        protected ClientParserAbstract(string ua)
            : base(ua)
        {
        }

        /// <summary>
        /// Parse.
        /// </summary>
        /// <returns>Returns Match.</returns>
        public new virtual ParseResult<TResult> Parse()
        {
            var result = new ParseResult<TResult>();

            if (!this.PreMatchOverall())
            {
                return result;
            }

            foreach (var regex in this.RegexList)
            {
                var matches = this.MatchUserAgent(regex.Regex);

                if (matches.Length > 0)
                {
                    var match = new TResult
                    {
                        Type = this.ParserName,
                        Name = this.BuildByMatch(regex.Name, matches),
                        Version = this.BuildVersion(regex.Version, matches),
                    };

                    result.Add(match);
                }
            }

            return result;
        }

        /// <summary>
        /// Get Available Clients.
        /// </summary>
        /// <returns>Returns List of Clients.</returns>
        public List<string> GetAvailableClients()
        {
            return this.RegexList.Where(r => r.Name != "$1").Select(r => r.Name).Distinct().OrderBy(o => o).ToList();
        }
    }
}
