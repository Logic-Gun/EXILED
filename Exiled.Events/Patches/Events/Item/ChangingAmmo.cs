// -----------------------------------------------------------------------
// <copyright file="ChangingAmmo.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Item
{
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Item;
    using Handlers;

    using HarmonyLib;
    using InventorySystem.Items.Firearms.Modules;

    /// <summary>
    /// Patches <see cref="MagazineModule.AmmoStored" />.
    /// Adds the <see cref="Item.ChangingAmmo" /> event.
    /// </summary>
    [EventPatch(typeof(Item), nameof(Item.ChangingAmmo))]
    [HarmonyPatch(typeof(MagazineModule), nameof(MagazineModule.AmmoStored), MethodType.Setter)]
    internal static class ChangingAmmo
    {
        private static bool Prefix(MagazineModule __instance, int value)
        {
            if (value == __instance.AmmoStored)
                return false;

            ChangingAmmoEventArgs ev = new ChangingAmmoEventArgs(__instance.Firearm, __instance.AmmoStored, value);

            Item.OnChangingAmmo(ev);

            return ev.IsAllowed;
        }
    }
}
