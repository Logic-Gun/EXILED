// -----------------------------------------------------------------------
// <copyright file="ChangingAmmoEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Item
{
    using Exiled.API.Features;
    using Exiled.API.Features.Items;
    using Exiled.Events.EventArgs.Interfaces;
    using BaseFirearm = InventorySystem.Items.Firearms.Firearm;
    using Firearm = API.Features.Items.Firearm;

    /// <summary>
    /// Contains all information before changing firearm ammo.
    /// </summary>
    public class ChangingAmmoEventArgs : IPlayerEvent, IFirearmEvent, IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangingAmmoEventArgs"/> class.
        /// </summary>
        /// <param name="basefirearm"><inheritdoc cref="Firearm"/></param>
        /// <param name="oldAmmo"><inheritdoc cref="OldAmmo"/></param>
        /// <param name="newAmmo"><inheritdoc cref="NewAmmo"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public ChangingAmmoEventArgs(BaseFirearm basefirearm, int oldAmmo, int newAmmo, bool isAllowed = true)
        {
            Firearm = Item.Get(basefirearm).As<Firearm>();
            Player = Firearm.Owner;
            OldAmmo = oldAmmo;
            NewAmmo = newAmmo;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets the <see cref="API.Features.Player"/> who's changing the <see cref="Firearm"/>'s ammo.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Gets the <see cref="API.Features.Items.Firearm"/> the ammo type is being changed to.
        /// </summary>
        public Firearm Firearm { get; }

        /// <inheritdoc/>
        public Item Item => Firearm;

        /// <summary>
        /// Gets the old ammo.
        /// </summary>
        public int OldAmmo { get; }

        /// <summary>
        /// Gets or sets the new ammo to be used by the firearm.
        /// </summary>
        public int NewAmmo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the ammo can be changed.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}
