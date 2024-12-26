// -----------------------------------------------------------------------
// <copyright file="Shooting.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Player
{
    using API.Features;

    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Player;

    using HarmonyLib;
    using InventorySystem.Items.Firearms;
    using InventorySystem.Items.Firearms.Modules.Misc;

    /// <summary>
    /// Patches <see cref="ShotBacktrackData.ProcessShot" />.
    /// Adds the <see cref="Handlers.Player.Shooting" /> events.
    /// </summary>
    [EventPatch(typeof(Handlers.Player), nameof(Handlers.Player.Shooting))]
    [HarmonyPatch(typeof(ShotBacktrackData), nameof(ShotBacktrackData.ProcessShot))]
    internal static class Shooting
    {
        private static bool Prefix(ShotBacktrackData __instance, Firearm firearm)
        {
            ShootingEventArgs ev = new(Player.Get(__instance.PrimaryTargetHub), firearm, ref __instance);

            Handlers.Player.OnShooting(ev);

            return ev.IsAllowed;
        }
    }
}