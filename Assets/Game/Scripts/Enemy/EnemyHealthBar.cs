using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer filledImage;

        private float _maxHealth;

        public void Construct(int maxHealth)
        {
            _maxHealth = maxHealth;
        }

        public void RefreshProgressBar(float currentHealth)
        {
            filledImage.size = new Vector2(currentHealth / _maxHealth, filledImage.size.y);
        }

        public void SetDefaultValue()
        {
            RefreshProgressBar(_maxHealth);
        }
    }
}