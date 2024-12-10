using Game.Scripts.Character;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Amo
{
    public class AmoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text amoText;
        
        private int _amountAmo;

        public void Construct(int amountAmo)
        {
            _amountAmo = amountAmo;
            amoText.text = _amountAmo.ToString();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.GetComponent<CharacterView>().PickUpAmo(_amountAmo);
            Destroy(gameObject);
        }
    }
}