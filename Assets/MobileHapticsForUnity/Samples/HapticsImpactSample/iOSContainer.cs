using UnityEngine;
using UnityEngine.UI;

namespace MobileHapticsForUnity.Sample
{
    public sealed class iOSContainer : MonoBehaviour
    {
        [SerializeField] SettingSlider intensity;
        [SerializeField] SettingSlider sharpness;
        [SerializeField] SettingSlider duration;
        [SerializeField] SettingSlider sustained;
        [SerializeField] Button impactButton;

        void Start()
        {
            impactButton.onClick.AddListener(() =>
            {
                Haptics.Impact(intensity.Value, sharpness.Value, duration.Value, sustained.Value);
            });
        }
    }
}
