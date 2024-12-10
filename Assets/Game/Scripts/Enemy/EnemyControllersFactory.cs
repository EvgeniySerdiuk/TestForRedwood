using Game.Scripts.Amo;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyControllersFactory
    {
        private readonly EnemyConfig[] _enemyConfigs;
        private readonly AmoSpawnController _amoSpawnController;

        public EnemyControllersFactory(EnemyConfig[] enemyConfigs, AmoSpawnController amoSpawnController)
        {
            _enemyConfigs = enemyConfigs;
            _amoSpawnController = amoSpawnController;
        }

        public EnemyController CreateRandomEnemyController()
        {
            var index = Random.Range(0, _enemyConfigs.Length);
            return new EnemyController(new EnemyModel(_enemyConfigs[index]), _enemyConfigs[index].View,
                _amoSpawnController);
        }
    }
}