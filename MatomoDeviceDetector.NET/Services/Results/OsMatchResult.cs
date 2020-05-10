// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="OsMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results
{
    using System;

    /// <summary>
    /// Os Match Result.
    /// </summary>
    public class OsMatchResult : IMatchResult
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the Short Name.
        /// </summary>
        public virtual string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the Platform.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Override String.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() =>
        $"ShortName: {this.ShortName}; " +
        $"{Environment.NewLine} " +
        $"Name: {this.Name};" +
        $"{Environment.NewLine} " +
        $"Version: {this.Version};" +
        $"{Environment.NewLine} " +
        $"Platform: {this.Platform};";
    }
}