// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="BrowserMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results.Client
{
    using System;

    /// <summary>
    /// BrowserMatchResult.
    /// </summary>
    public class BrowserMatchResult : ClientMatchResult
    {
        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the Engine.
        /// </summary>
        public string Engine { get; set; }

        /// <summary>
        /// Gets or sets the Engine Version.
        /// </summary>
        public string EngineVersion { get; set; }

        /// <summary>
        /// Override to String.
        /// </summary>
        /// <returns>Returns string.</returns>
        public override string ToString() =>
            base.ToString() +
            $"ShortName: {this.ShortName}; " +
            $"{Environment.NewLine} " +
            $"Engine: {this.Engine}; " +
            $"{Environment.NewLine} " +
            $"EngineVersion: {this.EngineVersion};";
    }
}