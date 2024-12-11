using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Character
{
    public class CharacterView : MonoBehaviour
    {
        public Action<int> OnTakeDamage;
        public Action<int> OnPickUpAmo;

        [field: SerializeField] public Transform BulletSpawnPosition { get; private set; }

        [SerializeField] private Animator characterAnimator;
        [SerializeField] private Animator weaponAnimator;

        private Coroutine _moveCoroutine;
        private float _speed;

        public void Construct(CharacterModel characterModel)
        {
            _speed = characterModel.Speed;
        }

        public void OnShotCancel(InputAction.CallbackContext obj)
        {
            weaponAnimator.SetTrigger("Off");
        }

        public void OnShot(InputAction.CallbackContext obj)
        {
            weaponAnimator.SetTrigger("On");
        }

        public void OnMoveCancel(InputAction.CallbackContext obj)
        {
            StopCoroutine(_moveCoroutine);
            characterAnimator.SetTrigger("Idle");
        }

        public void OnMove(InputAction.CallbackContext obj)
        {
            var value = obj.ReadValue<Vector2>();
            transform.localScale = new Vector2(value.x, transform.localScale.y);

            _moveCoroutine = StartCoroutine(Move(value));
        }

        private IEnumerator Move(Vector3 direction)
        {
            characterAnimator.SetTrigger("Run");

            while (true)
            {
                transform.position += direction * (_speed * Time.deltaTime);
                yield return null;
            }
        }

        public void TakeDamage(int amount)
        {
            OnTakeDamage?.Invoke(amount);
        }

        public void PickUpAmo(int amount)
        {
            OnPickUpAmo?.Invoke(amount);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}