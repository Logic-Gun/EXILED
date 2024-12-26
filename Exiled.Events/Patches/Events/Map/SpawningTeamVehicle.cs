// -----------------------------------------------------------------------
// <copyright file="SpawningTeamVehicle.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Map
{
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Map;

    using HarmonyLib;

    using Respawning;
    using Respawning.Waves;

    /// <summary>
    /// Patches <see cref="WaveUpdateMessage.ServerSendUpdate"/>.
    /// Adds the <see cref="Handlers.Map.SpawningTeamVehicle"/> event.
    /// </summary>
    [EventPatch(typeof(Handlers.Map), nameof(Handlers.Map.SpawningTeamVehicle))]
    [HarmonyPatch(typeof(WaveUpdateMessage), nameof(WaveUpdateMessage.ServerSendUpdate))]
    internal static class SpawningTeamVehicle
    {
        private static bool Prefix(SpawnableWaveBase spawnableWaveBase, UpdateMessageFlags updateMessageFlags)
        {
            SpawningTeamVehicleEventArgs ev = new(ref spawnableWaveBase, updateMessageFlags);

            Handlers.Map.OnSpawningTeamVehicle(ev);

            if (!ev.IsAllowed)
                return false;

            return true;
        }
    }
}