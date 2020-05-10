// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="PortableMediaPlayerParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Device
{
    using System.Collections.Generic;
    using MatomoDeviceDetectorNET.Services.Device;
    using MatomoDeviceDetectorNET.Services.Results;
    using MatomoDeviceDetectorNET.Services.Results.Device;

    /// <summary>
    /// Portable Media Player Parser.
    /// </summary>
    public class PortableMediaPlayerParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableMediaPlayerParser"/> class.
        /// </summary>
        public PortableMediaPlayerParser()
        {
            this.FixtureFile = "regexes/device/portable_media_player.yml";
            this.ParserName = "portablemediaplayer";
            this.RegexList = this.GetRegexes();
        }

        /// <summary>
        /// Parse.
        /// </summary>
        /// <returns>Match.</returns>
        public override ParseResult<DeviceMatchResult> Parse()
        {
            var result = new ParseResult<DeviceMatchResult>();
            return this.PreMatchOverall() ? base.Parse() : result;
        }
    }
}