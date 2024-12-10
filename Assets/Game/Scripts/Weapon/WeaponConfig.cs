using UnityEngine;

namespace Game.Scripts.Weapon
{
    [CreateAssetMenu(menuName = "Game/Weapon/" + nameof(WeaponConfig))]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float AttackSpeed { get; private set; }
        [field: SerializeField] public int StartAmountBullet { get; private set; }

        [field: SerializeField] public BulletView BulletView { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; }
        [field: SerializeField] public float DelayBeforeDisableBullet { get; private set; }
    }
}