using UnityEngine;

namespace Game.Scripts.Enemy
{
    [CreateAssetMenu(menuName = "Game/Enemy/" + nameof(EnemyConfig))]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public EnemyView View { get; private set; }

        //[field: SerializeField] public IDropableItemConfig {get; private set;}
    }
}