using Game.Scripts.Amo;
using Game.Scripts.Character;
using Game.Scripts.Enemy;
using UnityEngine;

namespace Game.Scripts.Match
{
    [CreateAssetMenu(menuName = "Game/Match/" + nameof(MatchConfig))]
    public class MatchConfig : ScriptableObject
    {
        [field: SerializeField] public CharacterConfig CharacterConfig { get; private set; }
        [field: SerializeField] public EnemySpawnConfig EnemySpawnConfig {get; private set;}
        [field: SerializeField] public AmoSpawnConfig AmoSpawnConfig {get; private set;}
        [field: SerializeField] public EnemyConfig[] EnemyConfigs {get; private set;}
    }
}