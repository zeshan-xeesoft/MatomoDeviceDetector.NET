// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedReader.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Client
{
    using YamlDotNet.Serialization;

    /// <summary>
    /// The Feed Reader Class.
    /// </summary>
    public class FeedReader : IClientParseLibrary
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
        /// Gets or sets the URL.
        /// </summary>
        [YamlMember(Alias = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        [YamlMember(Alias = "type")]
        public string Type { get; set; }
    }
}
