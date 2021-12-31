using UnityEngine;
using UnityEngine.UI;

namespace MobileHapticsForUnity.Sample
{
    public sealed class SampleCanvas : MonoBehaviour
    {
        [SerializeField] Button lightImpactButton;
        [SerializeField] Button mediumImpactButton;
        [SerializeField] Button heavyImpactButton;

        void Start()
        {
            lightImpactButton.onClick.AddListener(() =>
            {
                Haptics.Impact(ImpactFeedbackStyle.Light);
            });
            
            mediumImpactButton.onClick.AddListener(() =>
            {
                Haptics.Impact(ImpactFeedbackStyle.Medium);
            });
            
            heavyImpactButton.onClick.AddListener(() =>
            {
                Haptics.Impact(ImpactFeedbackStyle.Heavy);
            });
        }
    }
}
