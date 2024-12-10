using UnityEngine;

namespace Game.Scripts.SFX
{
    public class SFXController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip shotClip;
        [SerializeField] private AudioClip picUpAmoClip;
        [SerializeField] private AudioClip hitZombieClip;

        public void PlayHitZombieClip()
        {
            audioSource.PlayOneShot(hitZombieClip);
        }

        public void PlayPicUpAmoClip()
        {
            audioSource.PlayOneShot(picUpAmoClip);
        }

        public void PlayShotClip()
        {
            audioSource.PlayOneShot(shotClip, 0.8f);
        }
    }
}