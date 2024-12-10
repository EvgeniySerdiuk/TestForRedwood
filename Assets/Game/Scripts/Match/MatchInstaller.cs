using Game.Scripts.Character;
using Game.Scripts.Enemy;
using Game.Scripts.Match;
using UnityEngine;

public class MatchInstaller : MonoBehaviour
{
    [SerializeField] private MatchConfig matchConfig;

    private EnemyPool _enemyPool;
    private EnemySpawnController _spawnController;
    private EnemyControllersFactory _enemyControllersFactory;
    private CharacterControllerFactory _characterControllerFactory;

    private void Awake()
    {
        _enemyControllersFactory = new EnemyControllersFactory(matchConfig.EnemyConfigs);
        _enemyPool = new EnemyPool(_enemyControllersFactory);
        _spawnController = new EnemySpawnController(matchConfig.EnemySpawnConfig, _enemyPool);
        _characterControllerFactory = new CharacterControllerFactory(matchConfig.CharacterConfig);
    } 

    private void Start()
    {
        _characterControllerFactory.CreateCharacterController().CreateView();
        _spawnController.StartSpawn();
    }
}