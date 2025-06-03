using UnityEngine;
using UnityEngine.UI;

namespace Oscillator
{
    public class UI_Controller : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI textAngleLength;
        public TMPro.TextMeshProUGUI textTime;
        public int angle = 30;
        public int length = 5;
        public SimpleOscillator2D oscillator2D;

        private void Awake()
        {
            textAngleLength.text = $"Angle: {angle}¡Æ Length: {length}m";
        }

        private void Start()
        {
            oscillator2D.Set((float)angle, (float)length);
        }
    }
}
