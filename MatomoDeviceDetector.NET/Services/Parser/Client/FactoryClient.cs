// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryClient.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Parser.Client
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Factory Client.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    public class FactoryClient<T>
    {
        private static readonly Dictionary<string, Func<T>> Clients = new Dictionary<string, Func<T>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryClient{T}"/> class.
        /// </summary>
        private FactoryClient()
        {
        }

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <returns>Returns constructor.</returns>
        public static T Create(string name)
        {
            if (Clients.TryGetValue(name, out var constructor))
            {
                return constructor();
            }

            throw new ArgumentException("No type registered for this id");
        }

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="ctor">Ctor.</param>
        public static void Register(string name, Func<T> ctor)
        {
            Clients.Add(name, ctor);
        }
    }
}