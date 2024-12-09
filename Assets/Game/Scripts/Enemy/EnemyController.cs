using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts.Enemy
{
    public class EnemyController
    {
        public Action<EnemyController> OnDeath;

        private readonly EnemyModel _enemyModel;

        private EnemyView _enemyView;

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;
        }

        public void CreateView(Transform spawnRoot)
        {
            var viewPrefab = _enemyView;

            _enemyView = Object.Instantiate(viewPrefab, spawnRoot);
            _enemyView.Construct(_enemyModel);
        }

        public void EnableEnemy(Vector2 position)
        {
            _enemyView.transform.position = position;
            _enemyView.gameObject.SetActive(true);
        }

        public void StartMove(int direction)
        {
            _enemyView.StartMove(Vector2.right * direction);
        }

        public void DisableEnemy()
        {
            _enemyView.gameObject.SetActive(false);
        }

        private void Hit(int damage)
        {
            _enemyModel.TakeDamage(damage);
            _enemyView.HealthBar.RefreshProgressBar(_enemyModel.CurrentHealth);

            if (_enemyModel.CurrentHealth < 1)
            {
                OnDeath?.Invoke(this);
            }
        }
    }
}