namespace Game.Scripts.Enemy
{
    public class EnemyModel
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

        public float Speed { get; private set; }

        public EnemyModel(EnemyConfig config)
        {
            MaxHealth = config.Health;
            CurrentHealth = config.Health;
            Speed = config.MovementSpeed;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
        }

        public void ResetHealth()
        {
            CurrentHealth = MaxHealth;
        }
    }
}