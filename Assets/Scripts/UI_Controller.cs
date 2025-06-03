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

        public SimpleOscillator2D oscillator2D;

        private void Awake()
        {
            buttonStart.onClick.AddListener(OnButtonStartClicked);
        }

        private void Start()
        {
            int angle = System.Convert.ToInt32(textAngle.text);
            int length = System.Convert.ToInt32(textLength.text);

            oscillator2D.Set((float)angle, (float)length);
        }

        void OnButtonStartClicked()
        {
            
        }
    }
}
