// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IBotMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results
{
    using MatomoDeviceDetectorNET.Services;

    /// <summary>
    /// IBotMatchResult.
    /// </summary>
    public interface IBotMatchResult : IMatchResult
    {
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        string Category { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        string Url { get; set; }

        /// <summary>
        /// Gets or sets the Producer.
        /// </summary>
        Producer Producer { get; set; }
    }
}