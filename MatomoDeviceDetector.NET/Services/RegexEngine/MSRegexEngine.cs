// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="MSRegexEngine.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.RegexEngine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Microsoft Regex Engine for MatomoDeviceDetector.Net.
    /// </summary>
    public class MsRegexEngine : IRegexEngine
    {
        /// <summary>
        /// Match.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <returns>Success.</returns>
        public bool Match(string input, string pattern)
        {
            var match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            return match.Success;
        }

        /// <summary>
        /// Matches.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <returns>List.</returns>
        public IEnumerable<string> Matches(string input, string pattern)
        {
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            return matches.Cast<Match>().SelectMany(m => m.Groups.Cast<Group>().Select(g => g.Value));
        }

        /// <summary>
        /// Match Unique.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <returns>Match.</returns>
        public IEnumerable<string> MatchesUnique(string input, string pattern)
        {
            var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                foreach (Group group in match.Groups)
                {
                    if (!match.Value.Equals(group.Value))
                    {
                        yield return group.Value;
                    }
                }
            }
        }

        /// <summary>
        /// String replace.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <param name="replacement">Replacement.</param>
        /// <returns>Regex.</returns>
        public string Replace(string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }
    }
}