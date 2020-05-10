// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IClientMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results.Client
{
    /// <summary>
    /// IClientMatchResult.
    /// </summary>
    public interface IClientMatchResult : IMatchResult
    {
        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        string Version { get; set; }
    }
}