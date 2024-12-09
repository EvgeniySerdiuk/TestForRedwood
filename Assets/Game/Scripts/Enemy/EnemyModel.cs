namespace Game.Scripts.Enemy
{
    public class EnemyModel
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

        public float Speed { get; private set; }

        //private IDropableItemsConfigs[] _dropableItems;

        public EnemyModel(EnemyConfig config)
        {
            MaxHealth = config.Health;
            CurrentHealth = config.Health;
            Speed = config.MovementSpeed;

            //_dropableItems = config.Dropableitems
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
        }
    }
}