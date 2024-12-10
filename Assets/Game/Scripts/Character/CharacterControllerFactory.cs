using Game.Scripts.Weapon;

namespace Game.Scripts.Character
{
    public class CharacterControllerFactory
    {
        private readonly CharacterConfig _config;

        public CharacterControllerFactory(CharacterConfig config)
        {
            _config = config;
        }

        public CharacterController CreateCharacterController()
        {
            var newBulletPool = new BulletPool(_config.Weapon, _config.Weapon.StartAmountBullet * 2);
            return new CharacterController(_config.View, new CharacterModel(_config), newBulletPool);
        }
    }
}