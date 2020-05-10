// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="Model.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Device
{
    using YamlDotNet.Serialization;

    /// <summary>
    /// The Model Class.
    /// </summary>
    public class Model : IDeviceParseLibrary
    {
        /// <summary>
        /// Gets or sets the Regex.
        /// </summary>
        [YamlMember(Alias = "regex")]
        public string Regex { get; set; }

        /// <summary>
        /// Gets or sets the Model.
        /// </summary>
        [YamlMember(Alias = "model")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Device.
        /// </summary>
        [YamlMember(Alias = "device")]
        public string Device { get; set; }

        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        [YamlMember(Alias = "brand")]
        public string Brand { get; set; }
    }
}