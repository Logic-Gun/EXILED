// -----------------------------------------------------------------------
// <copyright file="PlacingBlood.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Map
{
    using Decals;
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Map;

    using HarmonyLib;

    using InventorySystem.Items.Firearms.Modules;

    using UnityEngine;

    /// <summary>
    /// Patches <see cref="ImpactEffectsModule.ServerSendImpactDecal"/>.
    /// Adds the <see cref="Handlers.Map.PlacingBlood"/> event.
    /// </summary>
    [EventPatch(typeof(Handlers.Map), nameof(Handlers.Map.PlacingBlood))]
    [HarmonyPatch(typeof(ImpactEffectsModule), nameof(ImpactEffectsModule.ServerSendImpactDecal))]
    internal static class PlacingBlood
    {
        private static bool Prefix(RaycastHit raycastHit, Vector3 origin, DecalPoolType decalPoolType)
        {
            PlacingBloodEventArgs ev = new(raycastHit.point, origin, decalPoolType);

            Handlers.Map.OnPlacingBlood(ev);

            if (!ev.IsAllowed)
                return false;

            raycastHit.point = ev.Point;
            origin = ev.Origin;
            decalPoolType = ev.DecalPoolType;

            return true;
        }
    }
}