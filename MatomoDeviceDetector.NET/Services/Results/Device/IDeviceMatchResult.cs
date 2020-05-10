// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeviceMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results.Device
{
    /// <summary>
    /// IDeviceMatchResult.
    /// </summary>
    public interface IDeviceMatchResult : IMatchResult
    {
        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        int? Type { get; set; }
    }
}