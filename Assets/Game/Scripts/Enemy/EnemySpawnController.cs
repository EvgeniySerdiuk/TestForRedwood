using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Enemy
{
    public class EnemySpawnController
    {
        private EnemySpawnConfig _enemySpawnConfig;
        private EnemyPool _enemyPool;
        private CancellationTokenSource _tokenSource;
        private Camera _camera;

        public EnemySpawnController(EnemySpawnConfig enemySpawnConfig, EnemyPool enemyPool)
        {
            _enemySpawnConfig = enemySpawnConfig;
            _enemyPool = enemyPool;
            _camera = Camera.main;
        }

        public void StartSpawn()
        {
            _enemyPool.CreatePool(_enemySpawnConfig.AmountEnemysForSpawn);
            _tokenSource = new CancellationTokenSource();

            Spawn().Forget();
        }

        public void StopSpawn()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        private async UniTaskVoid Spawn()
        {
            while (true)
            {
                var enemy = _enemyPool.GetRandomEnemy();

                var positionAndDirection = GetRandomPosition();

                enemy.EnableEnemy(positionAndDirection.Item1);
                enemy.StartMove(positionAndDirection.Item2);

                int delay = Random.Range(_enemySpawnConfig.RangeSpawnDelay.x, _enemySpawnConfig.RangeSpawnDelay.y + 1);

                await UniTask.Delay(TimeSpan.FromSeconds(delay));
            }
        }

        private (Vector2, int) GetRandomPosition()
        {
            Vector3 spawnPosition = Vector3.zero;
            int direction = 0;

            var randomPos = _camera.ViewportToWorldPoint(new Vector3(Random.Range(0, 2), 0, 0));

            switch (randomPos.x)
            {
                case 0:
                    randomPos.x -= 2;
                    direction = 1;
                    break;
                case 1:
                    randomPos.x += 2;
                    direction = -1;
                    break;
            }

            return (spawnPosition, direction);
        }
    }
}