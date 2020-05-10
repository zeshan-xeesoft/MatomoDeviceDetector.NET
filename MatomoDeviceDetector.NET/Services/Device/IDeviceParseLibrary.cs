// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeviceParseLibrary.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Device
{
    /// <summary>
    /// The IDevice Parse Library.
    /// </summary>
    public interface IDeviceParseLibrary : IParseLibrary
    {
        /// <summary>
        /// Gets or sets the Device.
        /// </summary>
        string Device { get; set; }
    }
}