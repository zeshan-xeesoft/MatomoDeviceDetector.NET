// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownClientMatchResult.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Results.Client
{
    /// <summary>
    /// Unknown Client Match Result.
    /// </summary>
    public class UnknownClientMatchResult : ClientMatchResult
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        public override string Type { get => "UNK"; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public override string Name { get => "UNK"; }
    }
}
