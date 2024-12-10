using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Character
{
    public class CharacterView : MonoBehaviour
    {
        [field: SerializeField] public Transform BulletSpawnPosition { get; private set; }
        [SerializeField] private Animator animator;

        private Coroutine _moveCoroutine;
        private float _speed;

        public void Construct(CharacterModel characterModel)
        {
            _speed = characterModel.Speed;
        }

        public void OnShotCancel(InputAction.CallbackContext obj)
        {
            animator.SetTrigger("Idle");
        }

        public void OnShot(InputAction.CallbackContext obj)
        {
            animator.SetTrigger("Attack");
        }

        public void OnMoveCancel(InputAction.CallbackContext obj)
        {
            StopCoroutine(_moveCoroutine);
            animator.SetTrigger("Idle");
        }

        public void OnMove(InputAction.CallbackContext obj)
        {
            var value = obj.ReadValue<Vector2>();
            transform.localScale = new Vector2(value.x, transform.localScale.y);

            _moveCoroutine = StartCoroutine(Move(value));
        }

        private IEnumerator Move(Vector3 direction)
        {
            animator.SetTrigger("Run");

            while (true)
            {
                transform.position += direction * (_speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}