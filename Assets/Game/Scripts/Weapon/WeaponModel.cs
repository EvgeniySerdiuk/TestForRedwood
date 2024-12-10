using System;

namespace Game.Scripts.Weapon
{
    public class WeaponModel
    {
        public Action<int> BulletAmountChanged;
        public Action BulletEnded;
        
        public int Damage { get; private set; }
        public float AttackSpeed { get; private set; }
        public int CurrentAmountBullet { get; private set; }

        public WeaponModel(WeaponConfig config)
        {
            Damage = config.Damage;
            CurrentAmountBullet = config.StartAmountBullet;
            AttackSpeed = config.AttackSpeed;
        }

        public void RefreshAmountBullet(int amount)
        {
            CurrentAmountBullet += amount;
            BulletAmountChanged.Invoke(CurrentAmountBullet);
            
            if (CurrentAmountBullet < 1)
            {
                BulletEnded?.Invoke();
            }
        }
    }
}