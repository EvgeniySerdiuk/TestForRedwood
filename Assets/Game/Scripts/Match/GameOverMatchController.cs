using Game.Scripts.Enemy;
using Game.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using CharacterController = Game.Scripts.Character.CharacterController;

namespace Game.Scripts.Match
{
    public class GameOverMatchController
    {
        private readonly CharacterController _characterController;
        private readonly MatchScreenUI _matchScreenUI;
        private readonly EnemySpawnController _spawnController;

        public GameOverMatchController(CharacterController characterController, MatchScreenUI matchScreenUI,
            EnemySpawnController spawnController)
        {
            _characterController = characterController;
            _matchScreenUI = matchScreenUI;
            _spawnController = spawnController;

            _characterController.CharacterDeath += GameOver;
        }

        private void GameOver()
        {
            _characterController.CharacterDeath -= GameOver;
            _spawnController.StopSpawn();
            InputSystem.actions.Disable();

            _matchScreenUI.GameOverScreen.RestartButton.onClick.AddListener(RestartGame);
            _matchScreenUI.GameOverScreen.ExitButton.onClick.AddListener(ExitGame);
            _matchScreenUI.ShowGameOverScreen();
        }

        private void RestartGame()
        {
            SceneManager.LoadScene("SampleScene");
            InputSystem.actions.Enable();
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}