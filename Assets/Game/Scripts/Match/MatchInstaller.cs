using Game.Scripts.Amo;
using Game.Scripts.Character;
using Game.Scripts.Enemy;
using Game.Scripts.Match;
using Game.Scripts.UI;
using UnityEngine;

public class MatchInstaller : MonoBehaviour
{
    [SerializeField] private MatchConfig matchConfig;
    [SerializeField] private MatchScreenUI matchScreenUI;

    private EnemyPool _enemyPool;
    private EnemySpawnController _spawnController;
    private EnemyControllersFactory _enemyControllersFactory;
    private CharacterControllerFactory _characterControllerFactory;
    private AmoSpawnController _amoSpawnController;

    private void Awake()
    {
        _amoSpawnController = new AmoSpawnController(matchConfig.AmoSpawnConfig);
        _enemyControllersFactory = new EnemyControllersFactory(matchConfig.EnemyConfigs, _amoSpawnController);
        _enemyPool = new EnemyPool(_enemyControllersFactory);
        _spawnController = new EnemySpawnController(matchConfig.EnemySpawnConfig, _enemyPool);
        _characterControllerFactory = new CharacterControllerFactory(matchConfig.CharacterConfig);
    }

    private void Start()
    {
        var character = _characterControllerFactory.CreateCharacterController();
        character.CreateView();
        
        matchScreenUI.Construct(character.GetModel());
        _spawnController.StartSpawn();
    }
}