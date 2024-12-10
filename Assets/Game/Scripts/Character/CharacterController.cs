using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Weapon;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

namespace Game.Scripts.Character
{
    public class CharacterController
    {
        public Action CharacterDeath;

        private readonly BulletPool _bulletPool;
        private readonly CharacterModel _characterModel;
        private readonly InputAction _moveAction;
        private readonly InputAction _attackAction;

        private CharacterView _characterView;
        private CancellationTokenSource _tokenSource;

        public CharacterController(CharacterView characterView, CharacterModel characterModel, BulletPool bulletPool)
        {
            _characterView = characterView;
            _characterModel = characterModel;
            _bulletPool = bulletPool;

            _moveAction = InputSystem.actions.FindAction("Move");
            _attackAction = InputSystem.actions.FindAction("Attack");
        }

        public void CreateView()
        {
            var viewPrefab = _characterView;
            _characterView = Object.Instantiate(viewPrefab, Vector3.zero, Quaternion.identity);
            _characterView.Construct(_characterModel);
            _characterView.OnPickUpAmo += PickUpAmo;
            _characterView.OnTakeDamage += TakeDamage;

            SubscribeInput();
        }

        private void TakeDamage(int damage)
        {
            _characterModel.TakeDamage(damage);

            if (_characterModel.CurrentHealth < 1)
            {
                UnsubscribeInput();
                CharacterDeath?.Invoke();
                Object.Destroy(_characterView.gameObject);
            }
        }

        public CharacterModel GetModel()
        {
            return _characterModel;
        }

        public CharacterView GetView()
        {
            return _characterView;
        }

        private void PickUpAmo(int amount)
        {
            _characterModel.Weapon.RefreshAmountBullet(amount);
        }

        private void SubscribeInput()
        {
            _moveAction.performed += _characterView.OnMove;
            _moveAction.canceled += _characterView.OnMoveCancel;

            _attackAction.started += OnShot;
            _attackAction.canceled += OnShotCancel;
        }

        private void UnsubscribeInput()
        {
            _moveAction.performed -= _characterView.OnMove;
            _moveAction.canceled -= _characterView.OnMoveCancel;

            _attackAction.started -= OnShot;
            _attackAction.canceled -= OnShotCancel;
        }

        private void OnShot(InputAction.CallbackContext obj)
        {
            if (_characterModel.Weapon.CurrentAmountBullet > 0)
            {
                _tokenSource = new CancellationTokenSource();
                _characterView.OnShot(obj);

                Shot().Forget();
            }
        }

        private void OnShotCancel(InputAction.CallbackContext obj)
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();

            _characterView.OnShotCancel(obj);
        }

        private async UniTaskVoid Shot()
        {
            while (!_tokenSource.IsCancellationRequested)
            {
                _bulletPool.GetBullet().MoveTo(_characterView.BulletSpawnPosition.position,
                    new Vector2(_characterView.transform.localScale.x, 0));

                _characterModel.Weapon.RefreshAmountBullet(-1);

                await UniTask.Delay(TimeSpan.FromSeconds(_characterModel.Weapon.AttackSpeed),
                    cancellationToken: _tokenSource.Token);
            }
        }
    }
}