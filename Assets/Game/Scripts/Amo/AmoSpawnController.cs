using UnityEngine;

namespace Game.Scripts.Amo
{
    public class AmoSpawnController
    {
        private AmoSpawnConfig _spawnConfig;

        public AmoSpawnController(AmoSpawnConfig spawnConfig)
        {
            _spawnConfig = spawnConfig;
        }

        public void RandomSpawnAmo(Vector2 spawnPosition)
        {
            if (Random.Range(0,101) <= _spawnConfig.ChanceSpawnAmo)
            {
                var amo = Object.Instantiate(_spawnConfig.View, spawnPosition, Quaternion.identity);
                amo.Construct(Random.Range(_spawnConfig.AmountSpawnRange.x, _spawnConfig.AmountSpawnRange.y));
            }
        }
    }
}