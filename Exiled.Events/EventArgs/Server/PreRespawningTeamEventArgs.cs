// -----------------------------------------------------------------------
// <copyright file="PreRespawningTeamEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Server
{
    using Exiled.Events.EventArgs.Interfaces;
    using PlayerRoles;
    using Respawning;
    using Respawning.Waves;

    /// <summary>
    /// Contains all information before setting up the environment for respawning a wave of <see cref="SpawnableTeamType.NineTailedFox" /> or
    /// <see cref="SpawnableTeamType.ChaosInsurgency" />.
    /// </summary>
    public class PreRespawningTeamEventArgs : IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreRespawningTeamEventArgs"/> class.
        /// </summary>
        /// <param name="spawnableWaveBase"><inheritdoc cref="SpawnableWaveBase"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public PreRespawningTeamEventArgs(ref SpawnableWaveBase spawnableWaveBase, bool isAllowed = true)
        {
            SpawnableWaveBase = spawnableWaveBase;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets or sets the <see cref="SpawnableWaveBase"/>.
        /// </summary>
        public SpawnableWaveBase SpawnableWaveBase { get; set; }

        /// <summary>
        /// Gets the maximum amount of respawnable players.
        /// </summary>
        public int MaxWaveSize => SpawnableWaveBase.MaxWaveSize;

        /// <summary>
        /// Gets a value indicating what the next respawnable team is.
        /// </summary>
        public Faction TargetFaction => SpawnableWaveBase.TargetFaction;

        /// <summary>
        /// Gets or sets a value indicating whether or not the spawn can occur.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}
