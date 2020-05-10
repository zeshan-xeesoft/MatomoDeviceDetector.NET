// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownOsMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results
{
    /// <summary>
    /// UnknownOsMatchResult.
    /// </summary>
    public class UnknownOsMatchResult : OsMatchResult
    {
        /// <summary>
        /// Gets the Name.
        /// </summary>
        public override string Name { get => "UNK"; }

        /// <summary>
        /// Gets the ShortName.
        /// </summary>
        public override string ShortName { get => "UNK"; }
    }
}
