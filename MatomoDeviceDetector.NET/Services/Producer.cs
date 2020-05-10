// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="Producer.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services
{
    using YamlDotNet.Serialization;

    /// <summary>
    /// The Producer class.
    /// </summary>
    public class Producer
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        [YamlMember(Alias = "url")]
        public string Url { get; set; }
    }
}
