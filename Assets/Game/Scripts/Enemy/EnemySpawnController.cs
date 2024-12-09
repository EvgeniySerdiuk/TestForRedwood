using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Enemy
{
    public class EnemySpawnController
    {
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly EnemyPool _enemyPool;
        private readonly Camera _camera;
        private readonly CancellationTokenSource _tokenSource;

        public EnemySpawnController(EnemySpawnConfig enemySpawnConfig, EnemyPool enemyPool)
        {
            _enemySpawnConfig = enemySpawnConfig;
            _enemyPool = enemyPool;
            _camera = Camera.main;
            _tokenSource = new CancellationTokenSource();
        }

        public void StartSpawn()
        {
            _enemyPool.CreatePool(_enemySpawnConfig.AmountEnemyInPool);
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
            int direction = 0;
            int randomSide = Random.Range(0, 2);
            Vector2 randomPos = _camera.ViewportToWorldPoint(new Vector2(randomSide, 0));

            switch (randomSide)
            {
                case 0:
                    randomPos.x -= _enemySpawnConfig.SpawnPositionOffset;
                    direction = 1;
                    break;
                case 1:
                    randomPos.x += _enemySpawnConfig.SpawnPositionOffset;
                    direction = -1;
                    break;
            }

            randomPos.y = 0;

            return (randomPos, direction);
        }
    }
}