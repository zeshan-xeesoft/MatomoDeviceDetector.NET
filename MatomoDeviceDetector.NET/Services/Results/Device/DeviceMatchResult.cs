// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results.Device
{
    using System;

    /// <summary>
    /// Device Match Result.
    /// </summary>
    public class DeviceMatchResult : IDeviceMatchResult
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Override String.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() =>
         $"Type: {this.Type}; " +
         $"{Environment.NewLine} " +
         $"Name: {this.Name};" +
         $"{Environment.NewLine} " +
         $"Brand: {this.Brand};";
    }
}