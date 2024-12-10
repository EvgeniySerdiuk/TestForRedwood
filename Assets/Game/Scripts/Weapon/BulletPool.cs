using System.Linq;
using UnityEngine;

namespace Game.Scripts.Weapon
{
    public class BulletPool
    {
        private readonly Transform _bulletRoot;
        private BulletView[] _bullets;

        public BulletPool(WeaponConfig weaponConfig, int count)
        {
            _bullets = new BulletView[count];
            _bulletRoot = new GameObject("BulletPool").transform;

            for (int i = 0; i < _bullets.Length; i++)
            {
                _bullets[i] = Object.Instantiate(weaponConfig.BulletView, _bulletRoot);
                _bullets[i].Construct(weaponConfig);
                _bullets[i].gameObject.SetActive(false);
            }
        }

        public BulletView GetBullet()
        {
            var bullet = _bullets.FirstOrDefault(x => !x.gameObject.activeSelf);
            bullet.gameObject.SetActive(true);
            
            return bullet;
        }
    }
}