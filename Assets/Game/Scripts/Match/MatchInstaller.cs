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
    [SerializeField] private CameraMatchController cameraMatchController;

    private EnemyPool _enemyPool;
    private EnemySpawnController _spawnController;
    private EnemyControllersFactory _enemyControllersFactory;
    private CharacterControllerFactory _characterControllerFactory;
    private AmoSpawnController _amoSpawnController;
    private GameOverMatchController _gameOverMatchController;

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
        StartMatch();
    }

    private void StartMatch()
    {
        var character = _characterControllerFactory.CreateCharacterController();
        character.CreateView();

        matchScreenUI.Construct(character.GetModel());
        cameraMatchController.SetTarget(character.GetView().transform);

        _gameOverMatchController = new GameOverMatchController(character, matchScreenUI, _spawnController);
        _spawnController.StartSpawn();
    }
}