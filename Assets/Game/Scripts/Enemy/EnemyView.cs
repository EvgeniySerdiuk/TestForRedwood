using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public Action<int> OnHit;

        [field: SerializeField] public EnemyHealthBar HealthBar { get; private set; }

        private float _speed;

        public void Construct(EnemyModel enemyModel)
        {
            _speed = enemyModel.Speed;
            
            HealthBar.Construct(enemyModel.MaxHealth);
        }

        public void Hit(int damage)
        {
            OnHit?.Invoke(damage);
        }

        public void StartMove(Vector2 direction)
        {
            HealthBar.SetDefaultValue();
            StartCoroutine(Move(direction));
        }

        private IEnumerator Move(Vector3 direction)
        {
            while (true)
            {
                transform.position += direction * (_speed * Time.deltaTime);
                yield return null;
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}