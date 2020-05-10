// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="VendorFragmentResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results
{
    using System;
    using MatomoDeviceDetectorNET.Services.Results.Device;

    /// <summary>
    /// Vendor Fragment Result.
    /// </summary>
    public class VendorFragmentResult : IDeviceMatchResult
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
        public int? Type { get => throw new System.NotSupportedException(); set => throw new System.NotSupportedException(); }

        /// <summary>
        /// Override String.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() =>
       $"Name: {this.Name};" +
       $"{Environment.NewLine} " +
       $"Brand: {this.Brand};";
    }
}