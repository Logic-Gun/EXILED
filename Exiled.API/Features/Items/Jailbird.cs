// -----------------------------------------------------------------------
// <copyright file="Jailbird.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.API.Features.Items
{
    using InventorySystem.Items.Jailbird;

    /// <summary>
    /// A wrapped class for <see cref="JailbirdItem"/>.
    /// </summary>
    public class Jailbird : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Jailbird"/> class.
        /// </summary>
        /// <param name="itemBase">The base <see cref="JailbirdItem"/> class.</param>
        public Jailbird(JailbirdItem itemBase)
            : base(itemBase)
        {
            Base = itemBase;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jailbird"/> class, as well as a new Jailbird item.
        /// </summary>
        internal Jailbird()
            : this((JailbirdItem)Server.Host.Inventory.CreateItemInstance(new(ItemType.Jailbird, 0), false))
        {
        }

        /// <summary>
        /// Gets the <see cref="JailbirdItem"/> that this class is encapsulating.
        /// </summary>
        public new JailbirdItem Base { get; }

        /// <summary>
        /// Gets or sets the amount of damage dealt with a Jailbird melee hit.
        /// </summary>
        public float MeleeDamage
        {
            get => Base._hitreg._damageMelee;
            set => Base._hitreg._damageMelee = value;
        }

        /// <summary>
        /// Gets or sets the amount of damage dealt with a Jailbird charge hit.
        /// </summary>
        public float ChargeDamage
        {
            get => Base._hitreg._damageCharge;
            set => Base._hitreg._damageCharge = value;
        }

        /// <summary>
        /// Gets or sets the amount of time in seconds that the <see cref="CustomPlayerEffects.Flashed"/> effect will be applied on being hit.
        /// </summary>
        public float FlashDuration
        {
            get => Base._hitreg._flashDuration;
            set => Base._hitreg._flashDuration = value;
        }

        /// <summary>
        /// Gets or sets the radius of the Jailbird's hit register.
        /// </summary>
        public float Radius
        {
            get => Base._hitreg._hitregRadius;
            set => Base._hitreg._hitregRadius = value;
        }

        /// <summary>
        /// Gets or sets the total amount of damage dealt with the Jailbird.
        /// </summary>
        public float TotalDamageDealt
        {
            get => Base._hitreg.TotalMeleeDamageDealt;
            set => Base._hitreg.TotalMeleeDamageDealt = value;
        }

        /// <summary>
        /// Gets or sets the amount of damage remaining before the Jailbird breaks.
        /// </summary>
        /// <remarks>Modifying this value will directly modify <see cref="TotalDamageDealt"/>.</remarks>
        /// <seealso cref="TotalDamageDealt"/>
        public float RemainingDamage
        {
            get => JailbirdItem.DamageLimit - TotalDamageDealt;
            set => TotalDamageDealt = JailbirdItem.DamageLimit - value;
        }

        /// <summary>
        /// Gets or sets the number of times the item has been charged and used.
        /// </summary>
        public int TotalCharges
        {
            get => Base.TotalChargesPerformed;
            set => Base.TotalChargesPerformed = value;
        }

        /// <summary>
        /// Gets or sets the amount of charges remaining before the Jailbird breaks.
        /// </summary>
        /// <remarks>Modifying this value will directly modify <see cref="TotalCharges"/>.</remarks>
        /// <seealso cref="TotalCharges"/>
        public int RemainingCharges
        {
            get => JailbirdItem.ChargesLimit - TotalCharges;
            set => TotalCharges = JailbirdItem.ChargesLimit - value;
        }

        /// <summary>
        /// Breaks the Jailbird.
        /// </summary>
        public void Break()
        {
            Base._broken = true;
            Base.SendRpc(JailbirdMessageType.Broken);
        }

        /// <summary>
        /// Clones current <see cref="Jailbird"/> object.
        /// </summary>
        /// <returns> New <see cref="Jailbird"/> object. </returns>
        public override Item Clone() => new Jailbird()
        {
            MeleeDamage = MeleeDamage,
            ChargeDamage = ChargeDamage,
            TotalDamageDealt = TotalDamageDealt,
            TotalCharges = TotalCharges,
        };

        /// <summary>
        /// Returns the JailBird in a human readable format.
        /// </summary>
        /// <returns>A string containing JailBird-related data.</returns>
        public override string ToString() => $"{Type} ({Serial}) [{Weight}] *{Scale}*";
    }
}