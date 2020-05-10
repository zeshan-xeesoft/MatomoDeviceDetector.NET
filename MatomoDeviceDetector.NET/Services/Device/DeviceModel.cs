// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceModel.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Device
{
    using System.Collections.Generic;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Device Model.
    /// </summary>
    public class DeviceModel : Model
    {
        /// <summary>
        /// Gets or sets the Models.
        /// </summary>
        [YamlMember(Alias = "models")]
        public List<Model> Models { get; set; }
    }
}