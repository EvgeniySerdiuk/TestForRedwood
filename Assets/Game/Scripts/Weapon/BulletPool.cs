using System.Linq;
using UnityEngine;

namespace Game.Scripts.Weapon
{
    public class BulletPool
    {
        private readonly Transform _bulletRoot;
        private readonly WeaponConfig _weaponConfig;
        private BulletView[] _bullets;

        public BulletPool(WeaponConfig weaponConfig, int count)
        {
            _weaponConfig = weaponConfig;
            _bullets = new BulletView[count];
            _bulletRoot = new GameObject("BulletPool").transform;

            CreateBullets(0);
        }

        public BulletView GetBullet()
        {
            var bullet = _bullets.FirstOrDefault(x => !x.gameObject.activeSelf);

            if (bullet == null)
            {
                bullet = AddBulletInPool();
            }

            bullet.gameObject.SetActive(true);

            return bullet;
        }

        private void CreateBullets(int startValueIterator)
        {
            for (int i = startValueIterator; i < _bullets.Length; i++)
            {
                _bullets[i] = Object.Instantiate(_weaponConfig.BulletView, _bulletRoot);
                _bullets[i].Construct(_weaponConfig);
                _bullets[i].gameObject.SetActive(false);
            }
        }

        private BulletView AddBulletInPool()
        {
            var length = _bullets.Length;
            var newPool = new BulletView[length * 2];
            _bullets.CopyTo(newPool, 0);
            _bullets = newPool;

            CreateBullets(length);

            return _bullets[^1];
        }
    }
}