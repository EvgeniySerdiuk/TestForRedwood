using Game.Scripts.SFX;
using Game.Scripts.Weapon;

namespace Game.Scripts.Character
{
    public class CharacterControllerFactory
    {
        private readonly CharacterConfig _config;
        private readonly SFXController _sfxController;

        public CharacterControllerFactory(CharacterConfig config, SFXController sfxController)
        {
            _config = config;
            _sfxController = sfxController;
        }

        public CharacterController CreateCharacterController()
        {
            var newBulletPool = new BulletPool(_config.Weapon, _config.Weapon.StartAmountBullet * 2);
            return new CharacterController(_config.View, new CharacterModel(_config), newBulletPool, _sfxController);
        }
    }
}