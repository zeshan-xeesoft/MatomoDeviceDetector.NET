// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="ClientType.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client
{
    /// <summary>
    /// Client Type.
    /// </summary>
    public class ClientType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientType"/> class.
        /// </summary>
        /// <param name="client">Client.</param>
        private ClientType(IClientParserAbstract client)
        {
            this.Client = client;
            this.Name = client.ParserName;
            this.FixtureFile = client.FixtureFile;
        }

        /// <summary>
        /// Gets the Browser.
        /// </summary>
        public static ClientType Browser => new ClientType(new BrowserParser());

        /// <summary>
        /// Gets the FeedReader.
        /// </summary>
        public static ClientType FeedReader => new ClientType(new FeedReaderParser());

        /// <summary>
        /// Gets the Library.
        /// </summary>
        public static ClientType Library => new ClientType(new LibraryParser());

        /// <summary>
        /// Gets the Media Player.
        /// </summary>
        public static ClientType MediaPlayer => new ClientType(new MediaPlayerParser());

        /// <summary>
        /// Gets the Mobile App.
        /// </summary>
        public static ClientType MobileApp => new ClientType(new MobileAppParser());

        /// <summary>
        /// Gets the PIM.
        /// </summary>
        public static ClientType PIM => new ClientType(new PimParser());

        /// <summary>
        /// Gets the Client.
        /// </summary>
        public IClientParserAbstract Client { get; }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the Fixture File.
        /// </summary>
        public string FixtureFile { get; }
    }
}
