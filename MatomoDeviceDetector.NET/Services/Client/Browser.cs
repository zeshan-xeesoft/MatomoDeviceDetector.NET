// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="Browser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Client
{
    using YamlDotNet.Serialization;

    /// <summary>
    /// The Browser Class.
    /// </summary>
    public class Browser : IParseLibrary, IClientParseLibrary
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
        [YamlMember(Alias = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the Engine.
        /// </summary>
        [YamlMember(Alias = "engine")]
        public Engine Engine { get; set; }
    }
}
