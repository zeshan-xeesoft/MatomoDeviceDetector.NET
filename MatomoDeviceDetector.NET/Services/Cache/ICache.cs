// --------------------------------------------------------------------------------------------------------------------------
// <copyright file="ICache.cs" company="Agile Flex Agency">
// Copyright © 2000-2020 by Agile Flex Agency. All rights reserved. Website: https://agile-flex.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------------

namespace MatomoDeviceDetectorNET.Services.Cache
{
    /// <summary>
    /// Interface ICache.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Gets the Fetch.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Returns true or false.</returns>
        object Fetch(string id);

        /// <summary>
        /// Gets the Contains.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Returns true or false.</returns>
        bool Contains(string id);

        /// <summary>
        /// Gets the Save state.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="data">Data.</param>
        /// <param name="lifeTime">Lifetime.</param>
        /// <returns>Returns true or false.</returns>
        bool Save(string id, object data, int lifeTime = 0);

        /// <summary>
        /// Gets the delete.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Returns true or false.</returns>
        bool Delete(string id);

        /// <summary>
        /// Gets the Flush All.
        /// </summary>
        /// <returns>Returns true or false.</returns>
        bool FlushAll();
    }
}