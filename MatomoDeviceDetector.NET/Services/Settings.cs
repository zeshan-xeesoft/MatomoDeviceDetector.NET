// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="Settings.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services
{
    /// <summary>
    /// Global DeviceDetector settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Initializes static members of the <see cref="Settings"/> class.
        /// </summary>
        static Settings()
        {
            RegexesDirectory = string.Empty;
        }

        /// <summary>
        /// Gets or sets the Regex Dir.
        /// </summary>
        public static string RegexesDirectory { get; set; }
    }
}
