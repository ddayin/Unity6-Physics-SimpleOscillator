using UnityEngine;
using UnityEngine.UI;

namespace Oscillator
{
    public class UI_Controller : MonoBehaviour
    {
        public Button buttonStart;
        public TMPro.TextMeshProUGUI textAngle;
        public TMPro.TextMeshProUGUI textLength;
        public TMPro.TextMeshProUGUI textTime;

        private void Awake()
        {
            buttonStart.onClick.AddListener(OnButtonStartClicked);
        }

        void OnButtonStartClicked()
        {
            
        }
    }
}
