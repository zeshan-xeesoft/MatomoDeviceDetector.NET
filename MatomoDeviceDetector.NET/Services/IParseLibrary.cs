// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IParseLibrary.cs" company="Agile Flex Agency">
// Copyright � 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services
{
    /// <summary>
    /// IParser Library.
    /// </summary>
    public interface IParseLibrary
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the Regex.
        /// </summary>
        string Regex { get; set; }
    }
}
