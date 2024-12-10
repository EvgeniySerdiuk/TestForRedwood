using Game.Scripts.Amo;
using Game.Scripts.SFX;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyControllersFactory
    {
        private readonly EnemyConfig[] _enemyConfigs;
        private readonly AmoSpawnController _amoSpawnController;
        private readonly SFXController _sfxController;

        public EnemyControllersFactory(EnemyConfig[] enemyConfigs, AmoSpawnController amoSpawnController, SFXController sfxController)
        {
            _enemyConfigs = enemyConfigs;
            _amoSpawnController = amoSpawnController;
            _sfxController = sfxController;
        }

        public EnemyController CreateRandomEnemyController()
        {
            var index = Random.Range(0, _enemyConfigs.Length);
            return new EnemyController(new EnemyModel(_enemyConfigs[index]), _enemyConfigs[index].View,
                _amoSpawnController, _sfxController);
        }
    }
}