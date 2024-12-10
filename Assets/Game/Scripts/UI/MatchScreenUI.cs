using Game.Scripts.Character;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class MatchScreenUI : MonoBehaviour
    {
        [SerializeField] private AmoCounterUI amoCounterUI;
        
        public void Construct(CharacterModel characterModel)
        {
            amoCounterUI.RefreshCounter(characterModel.Weapon.CurrentAmountBullet);
            characterModel.Weapon.BulletAmountChanged += amoCounterUI.RefreshCounter;
        }
    }
}