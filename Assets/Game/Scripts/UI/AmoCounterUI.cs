using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class AmoCounterUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text counterText;

        public void RefreshCounter(int newValue)
        {
            counterText.text = newValue.ToString();
        }
    }
}