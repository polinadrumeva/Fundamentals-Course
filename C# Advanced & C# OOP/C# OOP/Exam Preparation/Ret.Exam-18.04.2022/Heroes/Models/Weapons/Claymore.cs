﻿namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int damage = 20;

        public Claymore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            this.Durability--;
            if (this.Durability == 0)
            {
                return 0;
            }
            return damage;
        }
    }
}
