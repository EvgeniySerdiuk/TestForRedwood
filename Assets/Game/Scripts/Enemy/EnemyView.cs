using System;
using System.Collections;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public Action<int> OnHit;

        [field: SerializeField] public EnemyHealthBar HealthBar { get; private set; }
        [SerializeField] private Rigidbody2D rigidBody;

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
            var newScale = Vector3.one;
            newScale.x *= direction.x;
            transform.localScale = newScale;
            
            while (true)
            {
                var pos = direction * (_speed * Time.fixedDeltaTime);
                rigidBody.MovePosition(transform.position + pos);
                yield return new WaitForFixedUpdate();
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}