// -----------------------------------------------------------------------
// <copyright file="RespawningTeamEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Server
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Interfaces;
    using PlayerRoles;
    using Respawning;
    using Respawning.Waves;
    using System;
    using System.Collections.Generic;

#nullable enable
    /// <summary>
    /// Contains all information before spawning a wave of <see cref="SpawnableTeamType.NineTailedFox" /> or
    /// <see cref="SpawnableTeamType.ChaosInsurgency" />.
    /// </summary>
    public class RespawningTeamEventArgs : IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RespawningTeamEventArgs"/> class.
        /// </summary>
        /// <param name="spawnableWaveBase"><inheritdoc cref="SpawnableWaveBase"/></param>
        /// <param name="players"><inheritdoc cref="Players"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public RespawningTeamEventArgs(ref SpawnableWaveBase spawnableWaveBase, List<Player>? players = null, bool isAllowed = true)
        {
            SpawnableWaveBase = spawnableWaveBase;
            Players = players;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets or sets the current spawnable team.
        /// </summary>
        public SpawnableWaveBase SpawnableWaveBase { get; set; }

        /// <summary>
        /// Gets the target faction.
        /// </summary>
        public Faction TargetFaction => SpawnableWaveBase.TargetFaction;

        /// <summary>
        /// Gets the list of players that are going to be respawned.
        /// </summary>
        [Obsolete]
        public List<Player> Players { get; }

        /// <summary>
        /// Gets the maximum amount of respawnable players.
        /// </summary>
        public int MaxWaveSize => SpawnableWaveBase.MaxWaveSize;

        /// <summary>
        /// Gets or sets a value indicating whether or not the spawn can occur.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}
