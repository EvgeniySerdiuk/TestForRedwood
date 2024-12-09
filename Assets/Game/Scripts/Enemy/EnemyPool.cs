﻿using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyPool
    {
        private readonly EnemyControllersFactory _factory;

        private Transform _spawnRoot;
        private List<EnemyController> _notActiveEnemies;

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

            _spawnRoot = new GameObject("EnemyPool").transform;
            _notActiveEnemies = new();

            for (int i = 0; i < count; i++)
            {
                _notActiveEnemies[i] = _factory.CreateRandomEnemyController();
                _notActiveEnemies[i].CreateView(_spawnRoot);
                _notActiveEnemies[i].DisableEnemy();
                _notActiveEnemies[i].OnDeath += DisableEnemy;
            }
        }

        public EnemyController GetRandomEnemy()
        {
            var randomEnemy = _notActiveEnemies[Random.Range(0, _notActiveEnemies.Count)];
            _notActiveEnemies.Remove(randomEnemy);

            return randomEnemy;
        }

        private void DisableEnemy(EnemyController enemyController)
        {
            _notActiveEnemies.Add(enemyController);
        }
    }
}