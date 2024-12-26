// -----------------------------------------------------------------------
// <copyright file="ElevatorMovingAndArrived.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Map
{
    using Exiled.API.Features;
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Map;
    using HarmonyLib;
    using Interactables.Interobjects;
    using System.Collections.Generic;

    /// <summary>
    /// Patches <see cref="ElevatorChamber.ServerInteract"/>
    /// to add <see cref="Handlers.Map.ElevatorArrived"/> and <see cref="Handlers.Map.ElevatorMoving"/> events.
    /// </summary>
    [EventPatch(typeof(Handlers.Map), nameof(Handlers.Map.ElevatorArrived))]
    [EventPatch(typeof(Handlers.Map), nameof(Handlers.Map.ElevatorMoving))]
    [HarmonyPatch(typeof(ElevatorChamber), nameof(ElevatorChamber.ServerInteract))]
    internal class ElevatorMovingAndArrived
    {
        private static bool Prefix(ElevatorChamber __instance, Player pl, List<ElevatorDoor> floorDoors)
        {
            ElevatorMovingEventArgs ev = new(Lift.Get(__instance), pl, true);

            Handlers.Map.OnElevatorMoving(ev);

            if (!ev.IsAllowed)
            {
                return false;
            }

            ElevatorArrivedEventArgs arrivedEv = new(Lift.Get(__instance), pl);

            Handlers.Map.OnElevatorArrived(arrivedEv);

            return true;
        }
    }
}