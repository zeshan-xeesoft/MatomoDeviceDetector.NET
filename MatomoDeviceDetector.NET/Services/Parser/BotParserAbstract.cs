// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="BotParserAbstract.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services;
    using MatomoDeviceDetectorNET.Services.Results;

    /// <summary>
    /// BotParserAbstract.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    /// <typeparam name="TResult">TResult.</typeparam>
    public abstract class BotParserAbstract<T, TResult> : ParserAbstract<T, TResult>, IBotParserAbstract
        where T : class, IEnumerable<Bot>
        where TResult : class, IBotMatchResult, new()
    {
        /// <summary>
        /// Gets or sets a value indicating whether discarding.
        /// </summary>
        public bool DiscardDetails { get; set; }

        /// <summary>
        /// Parses the current UA and checks whether it contains bot information
        ///
        /// @see bots.yml for list of detected bots
        ///
        /// Step 1: Build a big regex containing all regexes and match UA against it
        /// -> If no matches found: return
        /// -> Otherwise:
        /// Step 2: Walk through the list of regexes in bots.yml and try to match every one
        /// -> Return the matched data
        ///
        /// If $discardDetails is set to TRUE, the Step 2 will be skipped
        /// $bot will be set to TRUE instead
        ///
        /// NOTE: Doing the big match before matching every single regex speeds up the detection.
        /// </summary>
        /// <returns>TResult.</returns>
        public override ParseResult<TResult> Parse()
        {
            var result = new ParseResult<TResult>();

            if (this.PreMatchOverall())
            {
                foreach (var bot in this.RegexList)
                {
                    var match = this.GetRegexEngine().Match(this.UserAgent, bot.Regex);

                    if (!match)
                    {
                        continue;
                    }

                    if (this.DiscardDetails)
                    {
                        result.Add(new TResult());
                        return result;
                    }

                    result.Add(new TResult
                    {
                        Name = bot.Name,
                        Category = bot.Category,
                        Url = bot.Url,
                        Producer = bot.Producer,
                    });
                }
            }

            return result;
        }
    }
}