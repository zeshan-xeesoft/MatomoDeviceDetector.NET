// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="BrowserEngine.cs" company="Agile Flex Agency">
// Copyright � 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Client
{
    using YamlDotNet.Serialization;

    /// <summary>
    /// The Browser Engine Class.
    /// </summary>
    public class BrowserEngine : IClientParseLibrary
    {
        /// <summary>
        /// Gets or sets the Regex.
        /// </summary>
        [YamlMember(Alias = "regex")]
        public string Regex { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        [YamlIgnore]
        public string Version { get; set; }
    }
}
