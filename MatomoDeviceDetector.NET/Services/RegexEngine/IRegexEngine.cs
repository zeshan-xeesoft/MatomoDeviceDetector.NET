// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IRegexEngine.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.RegexEngine
{
    using System.Collections.Generic;

    /// <summary>
    /// IRegexEngine.
    /// </summary>
    public interface IRegexEngine
    {
        /// <summary>
        /// Gets the Match.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <returns>Match.</returns>
        bool Match(string input, string pattern);

        /// <summary>
        /// List of matches.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <returns>List.</returns>
        IEnumerable<string> Matches(string input, string pattern);

        /// <summary>
        /// Matches Unique.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <returns>List of Unique.</returns>
        IEnumerable<string> MatchesUnique(string input, string pattern);

        /// <summary>
        /// Replace.
        /// </summary>
        /// <param name="input">Input.</param>
        /// <param name="pattern">Pattern.</param>
        /// <param name="replacement">Replacement.</param>
        /// <returns>String.</returns>
        string Replace(string input, string pattern, string replacement);
    }
}