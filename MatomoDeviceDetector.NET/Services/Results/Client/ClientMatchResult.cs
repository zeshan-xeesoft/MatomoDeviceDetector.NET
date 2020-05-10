// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results.Client
{
    using System;

    /// <summary>
    /// Client Match Result.
    /// </summary>
    public class ClientMatchResult : IClientMatchResult
    {
        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Ovrride String.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() =>
          $"Type: {this.Type}; " +
          $"{Environment.NewLine} " +
          $"Name: {this.Name};" +
          $"{Environment.NewLine} " +
          $"Version: {this.Version};" +
          $"{Environment.NewLine} ";
    }
}