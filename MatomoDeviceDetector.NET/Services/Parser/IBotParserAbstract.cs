// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IBotParserAbstract.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser
{
    /// <summary>
    /// IBotParserAbstract.
    /// </summary>
    public interface IBotParserAbstract : IParserAbstract
    {
        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the DiscardDetails.
        /// </summary>
        bool DiscardDetails { get; set; }
    }
}