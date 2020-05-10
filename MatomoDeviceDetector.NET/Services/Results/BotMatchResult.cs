// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="BotMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results
{
    using System;
    using MatomoDeviceDetectorNET.Services;

    /// <summary>
    /// Bot Match Result.
    /// </summary>
    public class BotMatchResult : IBotMatchResult
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Producer.
        /// </summary>
        public Producer Producer { get; set; }

        /// <summary>
        /// Override Type.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() =>
        $"Category: {this.Category}; " +
        $"{Environment.NewLine} " +
        $"Name: {this.Name};" +
        $"{Environment.NewLine} " +
        $"Url: {this.Url};" +
        $"{Environment.NewLine} " +
        $"Producer: {this.Producer?.Name};";
    }
}