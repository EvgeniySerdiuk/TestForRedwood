using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyPool
    {
        private readonly EnemyControllersFactory _factory;

        private Transform _spawnRoot;
        private List<EnemyController> _notActiveEnemies;
        private int _count;

        public EnemyPool(EnemyControllersFactory factory)
        {
            _factory = factory;
        }

        public void CreatePool(int count)
        {
            if (_notActiveEnemies != null)
            {
                Debug.LogWarning("Pool has been created!");
            }

            _count = count;
            _spawnRoot = new GameObject("EnemyPool").transform;
            _notActiveEnemies = new();

            for (int i = 0; i < count; i++)
            {
                var enemyController = _factory.CreateRandomEnemyController();
                enemyController.CreateView(_spawnRoot);
                enemyController.DisableEnemy();
                enemyController.OnDeath += DisableEnemy;

                _notActiveEnemies.Add(enemyController);
            }
        }

        public EnemyController GetRandomEnemy()
        {
            if (_notActiveEnemies.Count == 0)
            {
                AddEnemyInPool(_count);
            }

            var randomEnemy = _notActiveEnemies[Random.Range(0, _notActiveEnemies.Count)];
            _notActiveEnemies.Remove(randomEnemy);

            return randomEnemy;
        }

        private void DisableEnemy(EnemyController enemyController)
        {
            enemyController.DisableEnemy();
            _notActiveEnemies.Add(enemyController);
        }

        private void AddEnemyInPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var enemyController = _factory.CreateRandomEnemyController();
                enemyController.CreateView(_spawnRoot);
                enemyController.DisableEnemy();
                enemyController.OnDeath += DisableEnemy;

                _notActiveEnemies.Add(enemyController);
            }
        }
    }
}