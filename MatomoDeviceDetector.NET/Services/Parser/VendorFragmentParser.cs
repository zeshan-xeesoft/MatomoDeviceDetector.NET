// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="VendorFragmentParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser
{
    using System.Collections.Generic;
    using System.Linq;
    using MatomoDeviceDetectorNET.Services.Device;
    using MatomoDeviceDetectorNET.Services.Parser.Device;
    using MatomoDeviceDetectorNET.Services.Results;

    /// <summary>
    /// VendorFragmentParser.
    /// </summary>
    public class VendorFragmentParser : ParserAbstract<Dictionary<string, string[]>, VendorFragmentResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorFragmentParser"/> class.
        /// </summary>
        public VendorFragmentParser()
        {
            this.FixtureFile = "regexes/vendorfragments.yml";
            this.ParserName = "vendorfragments";
            this.RegexList = this.GetRegexes();
        }

        /// <summary>
        /// ParseResult.
        /// </summary>
        /// <returns>Result.</returns>
        public override ParseResult<VendorFragmentResult> Parse()
        {
            var result = new ParseResult<VendorFragmentResult>();

            foreach (var brands in this.RegexList)
            {
                foreach (var brand in brands.Value)
                {
                    if (this.IsMatchUserAgent(brand + "[^a-z0-9]+"))
                    {
                        result.Add(new VendorFragmentResult
                        {
                            Name = brands.Key,
                            Brand = DeviceParserAbstract<IDictionary<string, DeviceModel>, VendorFragmentResult>.DeviceBrands.FirstOrDefault(d => d.Value.Equals(brands.Key)).Key,
                        });
                    }
                }
            }

            return result;
        }
    }
}
