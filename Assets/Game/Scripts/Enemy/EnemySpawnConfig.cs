﻿using UnityEngine;

namespace Game.Scripts.Enemy
{
    [CreateAssetMenu(menuName = "Game/Enemy/" + nameof(EnemySpawnConfig))]
    public class EnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] public int AmountEnemysForSpawn { get; private set; }
        [field: SerializeField] public Vector2Int RangeSpawnDelay { get; private set; }
    }
}