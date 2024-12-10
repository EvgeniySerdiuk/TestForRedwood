using Game.Scripts.Weapon;
using UnityEngine;

namespace Game.Scripts.Character
{
    [CreateAssetMenu(menuName = "Game/Cgaracter/" + nameof(CharacterConfig))]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public CharacterView View { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public WeaponConfig Weapon { get; private set; }
    }
}