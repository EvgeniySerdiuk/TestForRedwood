using UnityEngine;

namespace Game.Scripts.Amo
{
    [CreateAssetMenu(menuName = "Game/Amo/" + nameof(AmoSpawnConfig))]
    public class AmoSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public Vector2Int AmountSpawnRange{ get; private set; }
        [field: SerializeField, Range(0,100)] public int ChanceSpawnAmo{ get; private set; }
        [field: SerializeField] public AmoView View { get; private set; }
    }
}