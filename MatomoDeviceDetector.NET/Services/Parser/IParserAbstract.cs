// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IParserAbstract.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser
{
    using MatomoDeviceDetectorNET.Services.Cache;

    /// <summary>
    /// IParserAbstract.
    /// </summary>
    public interface IParserAbstract
    {
        /// <summary>
        /// Gets the Fixture File.
        /// </summary>
        string FixtureFile { get; }

        /// <summary>
        /// Gets the ParserName.
        /// </summary>
        string ParserName { get; }

        /// <summary>
        /// SetUserAgent.
        /// </summary>
        /// <param name="ua">UA.</param>
        void SetUserAgent(string ua);

        /// <summary>
        /// Cache Provider.
        /// </summary>
        /// <param name="cacheProvider">Cache.</param>
        void SetCache(ICache cacheProvider);
    }
}
