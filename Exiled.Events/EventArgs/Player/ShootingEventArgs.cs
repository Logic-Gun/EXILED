// -----------------------------------------------------------------------
// <copyright file="ShootingEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Player
{
    using API.Features;

    using Exiled.API.Features.Items;

    using Interfaces;

    using InventorySystem.Items.Firearms.BasicMessages;
    using InventorySystem.Items.Firearms.Modules.Misc;
    using RelativePositioning;

    using UnityEngine;

    using BaseFirearm = InventorySystem.Items.Firearms.Firearm;

#nullable enable

    /// <summary>
    /// Contains all information before a player fires a weapon.
    /// </summary>
    public class ShootingEventArgs : IPlayerEvent, IDeniableEvent, IFirearmEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShootingEventArgs" /> class.
        /// </summary>
        /// <param name="shooter">
        /// <inheritdoc cref="Player" />
        /// </param>
        /// <param name="firearm">
        /// <inheritdoc cref="Firearm" />
        /// </param>
        /// <param name="shotBacktrackData">
        /// <inheritdoc cref="ShotBacktrackData"/>
        /// </param>
        public ShootingEventArgs(Player shooter, BaseFirearm firearm, ref ShotBacktrackData shotBacktrackData)
        {
            Player = shooter;
            Firearm = Item.Get(firearm).As<Firearm>();
            ShotBacktrackData = shotBacktrackData;
        }

        /// <summary>
        /// Gets the shotBacktrackData.
        /// </summary>
        public ShotBacktrackData ShotBacktrackData { get; }

        /// <summary>
        /// Gets the player who's shooting.
        /// </summary>
        public Player Player { get; }


        /// <summary>
        /// Gets the target of the shot.
        /// </summary>
        public Player? Target => ShotBacktrackData.HasPrimaryTarget ? Player.Get(ShotBacktrackData.PrimaryTargetHub) : null;

        /// <summary>
        /// Gets the target <see cref="API.Features.Items.Firearm" />.
        /// </summary>
        public Firearm Firearm { get; }

        /// <inheritdoc/>
        public Item Item => Firearm;

        /// <summary>
        /// Gets or sets the direction of the shot.
        /// </summary>
        public Vector3 Direction
        {
            get => Player.CameraTransform.forward;
            set => Player.CameraTransform.forward = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the shot can be fired.
        /// </summary>
        public bool IsAllowed { get; set; } = true;
    }
}