using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyControllersFactory
    {
        private readonly EnemyConfig[] _enemyConfigs;

        public EnemyControllersFactory(EnemyConfig[] enemyConfigs)
        {
            _enemyConfigs = enemyConfigs;
        }

        public EnemyController CreateRandomEnemyController()
        {
            var index = Random.Range(0, _enemyConfigs.Length);
            return new EnemyController(new EnemyModel(_enemyConfigs[index]), _enemyConfigs[index].View);
        }
    }
}