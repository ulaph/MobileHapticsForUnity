using UnityEngine;
using UnityEngine.UI;

namespace MobileHapticsForUnity.Sample
{
    public sealed class CommonContainer : MonoBehaviour
    {
        [SerializeField] Button lightImpactButton;
        [SerializeField] Button mediumImpactButton;
        [SerializeField] Button heavyImpactButton;
        [SerializeField] Button goToSettingButton;
        
        [SerializeField] GameObject iosContainer;
        [SerializeField] Button[] backButtons;

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
            
#if UNITY_EDITOR
            goToSettingButton.gameObject.SetActive(false);
#endif
            
            goToSettingButton.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
#if UNITY_IOS
                iosContainer.SetActive(true);
#elif UNITY_ANDROID

#endif
            });
            
            foreach (var backButton in backButtons)
            {
                backButton.onClick.AddListener(() =>
                {
                    gameObject.SetActive(true);
                    iosContainer.SetActive(false);
                });
            }
        }
    }
}
