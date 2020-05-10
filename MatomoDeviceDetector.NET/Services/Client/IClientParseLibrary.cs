// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IClientParseLibrary.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Client
{
    /// <summary>
    /// IClient Parse Library.
    /// </summary>
    public interface IClientParseLibrary : IParseLibrary
    {
        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        string Version { get; set; }
    }
}