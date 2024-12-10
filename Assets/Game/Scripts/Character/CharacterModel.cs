using Game.Scripts.Weapon;

namespace Game.Scripts.Character
{
    public class CharacterModel
    {
        public float Speed { get; private set; }
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public WeaponModel Weapon { get; private set; }

        public CharacterModel(CharacterConfig config)
        {
            Speed = config.Speed;
            CurrentHealth = config.Health;
            MaxHealth = config.Health;
            Weapon = new WeaponModel(config.Weapon);
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
        }
    }
}