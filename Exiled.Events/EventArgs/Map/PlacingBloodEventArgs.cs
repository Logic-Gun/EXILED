// -----------------------------------------------------------------------
// <copyright file="PlacingBloodEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Map
{
    using API.Features;
    using Decals;
    using Interfaces;

    using UnityEngine;

    /// <summary>
    /// Contains all information before placing a blood decal.
    /// </summary>
    public class PlacingBloodEventArgs : IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlacingBloodEventArgs" /> class.
        /// </summary>
        /// <param name="point">
        /// <inheritdoc cref="Vector3" />
        /// </param>
        /// <param name="origin">
        /// <inheritdoc cref="Vector3" />
        /// </param>
        /// <param name="decalPoolType">
        /// <inheritdoc cref="DecalPoolType" />
        /// </param>
        /// <param name="isAllowed">
        /// <inheritdoc cref="IsAllowed" />
        /// </param>
        public PlacingBloodEventArgs(Vector3 point, Vector3 origin, DecalPoolType decalPoolType, bool isAllowed = true)
        {
            Point = point;
            Origin = origin;
            DecalPoolType = decalPoolType;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets or sets the blood placing position.
        /// </summary>
        public Vector3 Point { get; set; }

        public Vector3 Origin { get; set; }

        /// <summary>
        /// Gets the player who placed the blood.
        /// </summary>
        public DecalPoolType DecalPoolType { get; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the blood can be placed.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}