// -----------------------------------------------------------------------
// <copyright file="RestartedRespawnSequenceEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Server
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using API.Enums;
    using API.Features;
    using Interfaces;
    using PlayerRoles;
    using PlayerRoles.RoleAssign;
    using Respawning;

    /// <summary>
    /// Contains all information after a new respawn sequence has been restarted.
    /// </summary>
    public class RestartedRespawnSequenceEventArgs : IExiledEvent
    {
        /// <summary>
        /// Gets the sequence's timer.
        /// </summary>
        public Stopwatch Timer => WaveManager._nextWave.ti;

        /// <summary>
        /// Gets or sets the time for the next sequence.
        /// </summary>
        public float TimeForNextSequence
        {
            get { }
            set
            {
                WaveManager._timeForNextSequence = value;
                Timer.Restart();
            }
        }
    }
}