// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="VersionTruncation.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser
{
    /// <summary>
    /// VersionTruncation.
    /// </summary>
    public static class VersionTruncation
    {
        /// <summary>
        /// Version constant used to set max version to major version only
        /// Version examples are: 3, 5, 6, 200, 123, ...
        /// </summary>
        public const int Major = 0;

        /// <summary>
        /// Version constant used to set max version to minor version
        /// Version examples are: 3.4, 5.6, 6.234, 0.200, 1.23, ...
        /// </summary>
        public const int Minor = 1;

        /// <summary>
        /// Version constant used to set max version to path level
        /// Version examples are: 3.4.0, 5.6.344, 6.234.2, 0.200.3, 1.2.3.
        /// </summary>
        public const int Patch = 2;

        /// <summary>
        /// Version constant used to set version to build number
        /// Version examples are: 3.4.0.12, 5.6.334.0, 6.234.2.3, 0.200.3.1, 1.2.3.0.
        /// </summary>
        public const int Build = 3;

        /// <summary>
        /// Version constant used to set version to unlimited (no truncation).
        /// </summary>
        public const int None = -1;
    }
}
