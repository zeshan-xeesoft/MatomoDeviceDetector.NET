// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParseResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ParseResult.
    /// </summary>
    /// <typeparam name="TMatch">TMatch.</typeparam>
    public class ParseResult<TMatch>
        where TMatch : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParseResult{TMatch}"/> class.
        /// </summary>
        public ParseResult()
        {
            this.Success = false;
            this.Matches = new List<TMatch>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParseResult{TMatch}"/> class.
        /// </summary>
        /// <param name="match">Match.</param>
        /// <param name="success">Sucess.</param>
        public ParseResult(TMatch match, bool success = true)
            : this()
        {
            this.Matches.Add(match);
            this.Success = success;
        }

        /// <summary>
        /// Gets a value indicating whether gets or sets the Success.
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Gets the Match.
        /// </summary>
        public TMatch Match => this.Success ? this.Matches.FirstOrDefault() : null;

        /// <summary>
        /// Gets or sets the Matches.
        /// </summary>
        public List<TMatch> Matches { get; set; }

        /// <summary>
        /// ParseResult.
        /// </summary>
        /// <param name="match">Match.</param>
        /// <returns>This.</returns>
        public ParseResult<TMatch> Add(TMatch match)
        {
            this.Matches.Add(match);
            this.Success = true;
            return this;
        }

        /// <summary>
        /// Add Range.
        /// </summary>
        /// <param name="matches">Matches.</param>
        /// <returns>This.</returns>
        public ParseResult<TMatch> AddRange(IEnumerable<TMatch> matches)
        {
            this.Matches.AddRange(matches);
            this.Success = true;
            return this;
        }

        /// <summary>
        /// Override String.
        /// </summary>
        /// <returns>Return String.</returns>
        public override string ToString() => this.Success ? this.Match.ToString() : "No matches!";
    }
}
