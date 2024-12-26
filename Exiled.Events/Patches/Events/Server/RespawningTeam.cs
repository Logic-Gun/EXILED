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
    using PlayerRoles;
    using Respawning;
    using Respawning.Waves;

    /// <summary>
    /// Patch the <see cref="WaveManager.Spawn"/>.
    /// Adds <see cref="Server.RespawningTeam"/> and <see cref="Server.DeployingTeamRole"/> events.
    /// </summary>
    [EventPatch(typeof(Server), nameof(Server.RespawningTeam))]
    [EventPatch(typeof(Server), nameof(Server.DeployingTeamRole))]
    [HarmonyPatch(typeof(WaveManager), nameof(WaveManager.Spawn))]
    internal static class RespawningTeam
    {
        private static bool Prefix(SpawnableWaveBase __instance)
        {
            RespawningTeamEventArgs ev = new(ref __instance);
            DeployingTeamRoleEventArgs deployingEv = new(null, RoleTypeId.None);
            // Add deploying team role event.
            // DeployingTeamRoleEventArgs ev = new()

            Server.OnRespawningTeam(ev);

            return ev.IsAllowed;
        }
    }
}