using UnityEngine;
﻿#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace MobileHapticsForUnity
{
    public enum ImpactFeedbackStyle
    {
        Light,
        Medium,
        Heavy,
    }
    public static class Haptics
    {
        public static bool Enabled = true;
#if UNITY_IOS
        [DllImport ("__Internal")]
        static extern void impact(int style);
#elif UNITY_ANDROID
        // Include in build to enable vibration permission for AndroidManifest.xml
        static void SetupAndroidManifest()
        {
            Handheld.Vibrate();
        }
#endif

        public static void Impact(ImpactFeedbackStyle style = ImpactFeedbackStyle.Light)
        {
            if (!Enabled)
            {
                return;
            }
#if UNITY_EDITOR
            Debug.Log($"impact style: {style}");
#elif UNITY_IOS
            impact(style.GetIOSValue());
#elif UNITY_ANDROID
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (var vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
            {
                long milliseconds = style.GetAndroidValue();
                if (AndroidVersionUtil.IsAfterOreo)
                {
                    var vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
                    var vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", milliseconds, -1);
                    vibrator.Call("vibrate", vibrationEffect);
                }
                else
                {
                    vibrator.Call("vibrate", milliseconds);
                }
            }
#endif
        }
    }
    
    public static class ImpactFeedbackStyleExtension
    {
#if UNITY_IOS
        public static int GetIOSValue(this ImpactFeedbackStyle style)
        {
            switch (style)
            {
                case ImpactFeedbackStyle.Light:
                    return 0;
                case ImpactFeedbackStyle.Medium:
                    return 1;
                case ImpactFeedbackStyle.Heavy:
                    return 2;
                default:
                    return 0;
            }
        }
#elif UNITY_ANDROID
        public static long GetAndroidValue(this ImpactFeedbackStyle style)
        {
            switch (style)
            {
                case ImpactFeedbackStyle.Light:
                    return 10;
                case ImpactFeedbackStyle.Medium:
                    return 20;
                case ImpactFeedbackStyle.Heavy:
                    return 30;
                default:
                    return 10;
            }
        }
#endif
    }
}
