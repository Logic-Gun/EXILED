// -----------------------------------------------------------------------
// <copyright file="Shot.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Player
{
#pragma warning disable SA1402 // File may only contain a single type

    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;

    using API.Features;

    using EventArgs.Player;
    using Exiled.Events.Attributes;
    using HarmonyLib;

    using InventorySystem.Items.Firearms;
    using InventorySystem.Items.Firearms.Modules;
    using NorthwoodLib.Pools;
    using UnityEngine;

    using static HarmonyLib.AccessTools;

    using Item = API.Features.Items.Item;

    /// <summary>
    /// Patches <see cref="HitscanHitregModuleBase.ServerProcessTargetHit" />.
    /// Adds the <see cref="Handlers.Player.Shot" /> events.
    /// </summary>
    [EventPatch(typeof(Handlers.Player), nameof(Handlers.Player.Shot))]
    [HarmonyPatch(typeof(HitscanHitregModuleBase), nameof(HitscanHitregModuleBase.ServerProcessTargetHit))]
    internal static class Shot
    {
        /// <summary>
        /// Process shot.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="firearm">The firearm.</param>
        /// <param name="hit">The raycast hit.</param>
        /// <param name="destructible">The destructible.</param>
        /// <param name="damage">The damage.</param>
        /// <returns>If the shot is allowed.</returns>
        private static bool ProcessShot(ReferenceHub player, Firearm firearm, RaycastHit hit, IDestructible destructible, ref float damage)
        {
            ShotEventArgs shotEvent = new(Player.Get(player), Item.Get(firearm).Cast<API.Features.Items.Firearm>(), hit, destructible, damage);

            Handlers.Player.OnShot(shotEvent);

            if (shotEvent.CanHurt)
                damage = shotEvent.Damage;

            return shotEvent.CanHurt;
        }

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Shared.Rent();

            int index = newInstructions.FindIndex(r =>

                r.opcode == OpCodes.Call && (MethodInfo)r.operand ==
                Method(typeof(HitscanHitregModuleBase), nameof(HitscanHitregModuleBase.SendDamageIndicator)));

            index += -4; // offset

            Label returnLabel = generator.DefineLabel();

            newInstructions.InsertRange(index, new[]
            {
                // ReferenceHub owner = this.Owner
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Call, Method(typeof(HitscanHitregModuleBase), nameof(HitscanHitregModuleBase.Owner))),
                new CodeInstruction(OpCodes.Stloc_3),

                // Firearm firearm = this.Firearm
                new CodeInstruction(OpCodes.Call, Method(typeof(HitscanHitregModuleBase), nameof(HitscanHitregModuleBase.Firearm))),
                new CodeInstruction(OpCodes.Stloc_S, 4),

                // ProcessShot(owner, firearm, hit, destructible, ref damage)
                new CodeInstruction(OpCodes.Ldloc_3),
                new CodeInstruction(OpCodes.Ldloc_S, 4),
                new CodeInstruction(OpCodes.Ldarg_1),
                new CodeInstruction(OpCodes.Ldarg_2),
                new CodeInstruction(OpCodes.Ldloc_0), // possible need add ref
                new CodeInstruction(OpCodes.Call, Method(typeof(Shot), nameof(ProcessShot))),
                new CodeInstruction(OpCodes.Brfalse, returnLabel),
            });

            newInstructions[newInstructions.Count - 1].WithLabels(returnLabel);

            for (int i = 0; i < newInstructions.Count; i++)
                yield return newInstructions[i];

            ListPool<CodeInstruction>.Shared.Return(newInstructions);
        }
    }
}
