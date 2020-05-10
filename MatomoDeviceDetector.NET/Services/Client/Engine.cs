// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="Engine.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Client
{
    using System.Collections.Generic;
    using YamlDotNet.Serialization;

    /// <summary>
    /// The Engine class.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Gets or sets the Default.
        /// </summary>
        [YamlMember(Alias = "default")]
        public string Default { get; set; }

        /// <summary>
        /// Gets or sets the Versions.
        /// </summary>
        [YamlMember(Alias = "versions")]
        public Dictionary<string, string> Versions { get; set; }
    }
}
