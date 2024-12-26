// -----------------------------------------------------------------------
// <copyright file="SpawningTeamVehicleEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Map
{
    using Exiled.Events.EventArgs.Interfaces;
    using Respawning;
    using Respawning.Waves;

    /// <summary>
    /// Contains all information before the server spawns a team's respawn vehicle.
    /// </summary>
    public class SpawningTeamVehicleEventArgs : IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpawningTeamVehicleEventArgs" /> class.
        /// </summary>
        /// <param name="spawnableWaveBase">
        /// The team who the vehicle belongs to.
        /// </param>
        /// <param name="updateMessageFlags">
        /// The flags of the update message.
        /// </param>
        /// <param name="isAllowed">
        /// <inheritdoc cref="IsAllowed" />
        /// </param>
        public SpawningTeamVehicleEventArgs(ref SpawnableWaveBase spawnableWaveBase, UpdateMessageFlags updateMessageFlags, bool isAllowed = true)
        {
            Wave = spawnableWaveBase;
            Flags = updateMessageFlags;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets or sets which vehicle should spawn.
        /// </summary>
        public SpawnableWaveBase Wave { get; set; }

        /// <summary>
        /// Gets the flags of the update message.
        /// </summary>
        public UpdateMessageFlags Flags { get; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the vehicle can be spawned.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}