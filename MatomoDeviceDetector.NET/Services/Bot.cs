// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bot.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services
{
    using YamlDotNet.Serialization;

    /// <summary>
    /// The Bot Parser Library.
    /// </summary>
    public class Bot : IParseLibrary
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
        /// Gets or sets the Category.
        /// </summary>
        [YamlMember(Alias = "category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        [YamlMember(Alias = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Producer.
        /// </summary>
        [YamlMember(Alias = "producer")]
        public Producer Producer { get; set; }
    }
}
