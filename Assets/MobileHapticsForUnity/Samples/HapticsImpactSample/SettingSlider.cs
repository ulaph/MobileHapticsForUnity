using UnityEngine;
using UnityEngine.UI;

namespace MobileHapticsForUnity.Sample
{
    public sealed class SettingSlider : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] InputField inputField;

        public float Value => slider.value;

        void Start()
        {
            inputField.contentType = InputField.ContentType.DecimalNumber;
            
            slider.onValueChanged.AddListener((value) =>
            {
                inputField.SetTextWithoutNotify($"{value:0.##}");
            });
            
            inputField.onValueChanged.AddListener((text) =>
            {
                var value = Mathf.Clamp(float.Parse(text), slider.minValue, slider.maxValue);
                slider.SetValueWithoutNotify(value);
                inputField.SetTextWithoutNotify($"{value:0.##}");
            });
        }
    }
}
