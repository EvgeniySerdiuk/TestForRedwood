using Game.Scripts.Enemy;
using Game.Scripts.Match;
using UnityEngine;

public class MatchInstaller : MonoBehaviour
{
    [SerializeField] private MatchConfig matchConfig;

    private EnemyPool _enemyPool;
    private EnemySpawnController _spawnController;
    private EnemyControllersFactory _enemyControllersFactory;

    private void Awake()
    {
        _enemyControllersFactory = new EnemyControllersFactory(matchConfig.EnemyConfigs);
        _enemyPool = new EnemyPool(_enemyControllersFactory);
        _spawnController = new EnemySpawnController(matchConfig.EnemySpawnConfig, _enemyPool);
    }

    private void Start()
    {
        _spawnController.StartSpawn();
    }
}