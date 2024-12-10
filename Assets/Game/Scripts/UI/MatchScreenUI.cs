using Game.Scripts.Character;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class MatchScreenUI : MonoBehaviour
    {
        [field: SerializeField] public AmoCounterUI AmoCounterUI {get; private set;}
        [field: SerializeField] public GameOverScreen GameOverScreen {get; private set;}
        
        public void Construct(CharacterModel characterModel)
        {
            AmoCounterUI.RefreshCounter(characterModel.Weapon.CurrentAmountBullet);
            characterModel.Weapon.BulletAmountChanged += AmoCounterUI.RefreshCounter;
        }

        public void ShowGameOverScreen()
        {
            GameOverScreen.Show();
        }
    }
}