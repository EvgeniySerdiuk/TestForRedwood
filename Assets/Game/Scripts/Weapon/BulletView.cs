using System.Collections;
using Game.Scripts.Enemy;
using UnityEngine;

namespace Game.Scripts.Weapon
{
    public class BulletView : MonoBehaviour
    {
        private int _damage;
        private float _delayBeforeDisable;
        private float _speed;

        public void Construct(WeaponConfig config)
        {
            _damage = config.Damage;
            _delayBeforeDisable = config.DelayBeforeDisableBullet;
            _speed = config.BulletSpeed;
        }

        public void MoveTo(Vector2 startPosition, Vector2 direction)
        {
            transform.position = startPosition;
            
            StartCoroutine(DisableDelay());
            StartCoroutine(Move(direction));
        }
        
        private IEnumerator Move(Vector3 direction)
        {
            var newScale = transform.localScale;
            newScale.x *= direction.x;
            transform.localScale = newScale;
            
            while (true)
            {
                var pos = direction * (_speed * Time.deltaTime);
                transform.position += pos;
                yield return null;
            }
        }

        private IEnumerator DisableDelay()
        {
            yield return new WaitForSeconds(_delayBeforeDisable);
            Disable();
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<EnemyView>().Hit(_damage);
            Disable();
        }

        private void Disable()
        {
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }
}