using UnityEngine;
using UnityEngine.UI;

namespace Oscillator
{
    public class UI_Controller : MonoBehaviour
    {
        public Button buttonStart;
        public InputField inputAngle;
        public InputField inputLength;
        public TMPro.TextMeshProUGUI textTime;

        public SimpleOscillator2D oscillator2D;

        private void Awake()
        {
            buttonStart.onClick.AddListener(OnButtonStartClicked);
        }

        private void Start()
        {
            int angle = System.Convert.ToInt32(inputAngle.text);
            int length = System.Convert.ToInt32(inputLength.text);

            oscillator2D.Set((float)angle, (float)length);
        }

        void OnButtonStartClicked()
        {
            
        }
    }
}
