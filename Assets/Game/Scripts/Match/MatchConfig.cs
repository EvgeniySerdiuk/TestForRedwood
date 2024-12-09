using Game.Scripts.Enemy;
using UnityEngine;

namespace Game.Scripts.Match
{
    [CreateAssetMenu(menuName = "Game/Match/" + nameof(MatchConfig))]
    public class MatchConfig : ScriptableObject
    {
        [field: SerializeField] public EnemyConfig[] EnemyConfigs {get; private set;}
        [field: SerializeField] public EnemySpawnConfig EnemySpawnConfig {get; private set;}
    }
}