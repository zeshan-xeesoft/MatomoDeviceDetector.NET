// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeviceParserAbstract.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Device
{
    /// <summary>
    /// IDeviceParserAbstract.
    /// </summary>
    public interface IDeviceParserAbstract : IParserAbstract
    {
        /// <summary>
        /// Get the Model.
        /// </summary>
        /// <returns>String.</returns>
        string GetModel();

        /// <summary>
        /// Get the Brand.
        /// </summary>
        /// <returns>String.</returns>
        string GetBrand();
    }
}