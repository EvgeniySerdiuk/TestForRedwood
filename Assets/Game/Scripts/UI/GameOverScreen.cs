using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Scripts.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [field: SerializeField] public Button RestartButton { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }

        [SerializeField] private CanvasGroup canvasGroup;

        public void Show()
        {
            canvasGroup.alpha = 1;
        }
    }
}