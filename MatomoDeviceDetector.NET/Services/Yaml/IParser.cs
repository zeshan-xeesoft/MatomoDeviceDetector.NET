// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="IParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Yaml
{
    using System.Collections;
    using System.IO;

    /// <summary>
    /// IParser.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public interface IParser<T>
        where T : IEnumerable
    {
        /// <summary>
        /// Parse File.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Parse.</returns>
        T ParseFile(string file);

        /// <summary>
        /// Parse Stream.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <returns>Parsed.</returns>
        T ParseStream(Stream stream);
    }
}
