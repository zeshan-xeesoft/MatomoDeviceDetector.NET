// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="YamlParser.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Yaml
{
    using System.Collections;
    using System.IO;
    using YamlDotNet.Core;
    using YamlDotNet.Core.Events;
    using YamlDotNet.Serialization;

    /// <summary>
    /// YamlParser.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public class YamlParser<T> : IParser<T>
        where T : class, IEnumerable// IParseLibrary
    {
        /// <summary>
        /// Parse File.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Parsed.</returns>
        public T ParseFile(string file)
        {
            using (var r = new StreamReader(file))
            {
                return this.ParseStreamReader(r);
            }
        }

        /// <summary>
        /// ParseStream.
        /// </summary>
        /// <param name="stream">Stram.</param>
        /// <returns>Parsed.</returns>
        public T ParseStream(Stream stream)
        {
            using (var r = new StreamReader(stream))
            {
                return this.ParseStreamReader(r);
            }
        }

        /// <summary>
        /// Parse Stream Reader.
        /// </summary>
        /// <param name="streamReader">Stream reader.</param>
        /// <returns>Deserialized.</returns>
        private T ParseStreamReader(StreamReader streamReader)
        {
            var deserializer = new DeserializerBuilder().Build();
            var parser = new YamlDotNet.Core.Parser(streamReader);

            parser.Expect<StreamStart>();

            while (parser.Accept<DocumentStart>())
            {
                return deserializer.Deserialize<T>(parser);
            }

            return null;
        }
    }
}
