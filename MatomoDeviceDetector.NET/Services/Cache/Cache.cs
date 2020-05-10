// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="Cache.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Cache
{
    using System.Collections.Concurrent;

    /// <summary>
    /// Dictionary Class Cache.
    /// </summary>
    public class Cache : ICache
    {
        private static ConcurrentDictionary<string, object> staticCache = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// Contains.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Returns true or false.</returns>
        public bool Contains(string id)
        {
            return staticCache != null && staticCache.Keys.Count > 0 && staticCache.ContainsKey(id);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Returns true or false.</returns>
        public bool Delete(string id)
        {
            if (this.Contains(id))
            {
                staticCache.TryRemove(id, out _);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Fetch.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Returns true or false.</returns>
        public object Fetch(string id)
        {
            return this.Contains(id) ? staticCache[id] : null;
        }

        /// <summary>
        /// Flush all.
        /// </summary>
        /// <returns>Returns true or false.</returns>
        public bool FlushAll()
        {
            staticCache = new ConcurrentDictionary<string, object>();
            return true;
        }

        /// <summary>
        /// Save.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">Data.</param>
        /// <param name="lifeTime">Lifetime.</param>
        /// <returns>Returns true or false.</returns>
        public bool Save(string id, object data, int lifeTime = 0)
        {
            if (this.Contains(id))
            {
                staticCache[id] = data;
            }
            else
            {
                staticCache.TryAdd(id, data);
            }

            return true;
        }
    }
}