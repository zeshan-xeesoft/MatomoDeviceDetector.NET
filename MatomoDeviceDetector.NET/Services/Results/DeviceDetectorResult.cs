// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceDetectorResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results
{
    using System;
    using MatomoDeviceDetectorNET.Services.Results.Client;

    /// <summary>
    /// Device Detector Result.
    /// </summary>
    public class DeviceDetectorResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDetectorResult"/> class.
        /// </summary>
        public DeviceDetectorResult()
        {
            this.OsFamily = "Unknown";
            this.BrowserFamily = "Unknown";
        }

        /// <summary>
        /// Gets or sets the User Agent.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the Bot.
        /// </summary>
        public BotMatchResult Bot { get; set; }

        /// <summary>
        /// Gets or sets the OS.
        /// </summary>
        public OsMatchResult Os { get; set; }

        /// <summary>
        /// Gets or sets the Client.
        /// </summary>
        public ClientMatchResult Client { get; set; }

        /// <summary>
        /// Gets or sets the DeviceType.
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// Gets or sets the DeviceBrand.
        /// </summary>
        public string DeviceBrand { get; set; }

        /// <summary>
        /// Gets or sets the DeviceModel.
        /// </summary>
        public string DeviceModel { get; set; }

        /// <summary>
        /// Gets or sets the OsFamily.
        /// </summary>
        public string OsFamily { get; set; }

        /// <summary>
        /// Gets or sets the BrowserFamily.
        /// </summary>
        public string BrowserFamily { get; set; }

        /// <summary>
        /// Override String.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString() =>
        $"UserAgent: {this.UserAgent}; " +
        $"{Environment.NewLine} " +
        $"DeviceType: {this.DeviceType}" +
        $"{Environment.NewLine} " +
        $"DeviceBrand: {this.DeviceBrand}" +
        $"{Environment.NewLine} " +
        $"DeviceModel: {this.DeviceModel}" +
        $"{Environment.NewLine} " +
        $"BrowserFamily: {this.BrowserFamily}" +
        $"{Environment.NewLine} " +
        $"Bot: {this.Bot}" +
        $"{Environment.NewLine} " +
        $"Os: {this.Os}" +
        $"{Environment.NewLine} " +
        $"Client: {this.Client}";
    }
}