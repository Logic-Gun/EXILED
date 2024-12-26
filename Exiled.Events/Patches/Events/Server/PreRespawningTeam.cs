// -----------------------------------------------------------------------
// <copyright file="RespawningTeam.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Server
{
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Server;
    using Exiled.Events.Handlers;
    using HarmonyLib;
    using Respawning;
    using Respawning.Waves;

    /// <summary>
    /// Patch the <see cref="WaveManager.InitiateRespawn"/>.
    /// Adds <see cref="Server.PreRespawningTeam"/> and <see cref="Server.DeployingTeamRole"/> events.
    /// </summary>
    [EventPatch(typeof(Server), nameof(Server.PreRespawningTeam))]
    [HarmonyPatch(typeof(WaveManager), nameof(WaveManager.InitiateRespawn))]
    internal static class PreRespawningTeam
    {
        private static bool Prefix(SpawnableWaveBase __instance)
        {
            PreRespawningTeamEventArgs ev = new(ref __instance);

            Server.OnPreRespawningTeam(ev);

            return ev.IsAllowed;
        }
    }
}