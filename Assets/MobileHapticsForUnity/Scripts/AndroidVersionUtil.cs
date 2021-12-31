using UnityEngine;

namespace MobileHapticsForUnity
{
    public class AndroidVersionUtil
    {
        public static bool IsAfterOreo
        {
            get
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                var versionCodesClass = new AndroidJavaClass("android.os.Build$VERSION_CODES");
                var versionClass = new AndroidJavaClass("android.os.Build$VERSION");
                return versionClass.GetStatic<int>("SDK_INT") >= versionCodesClass.GetStatic<int>("O");
#else
                return false;
#endif
            }
        }
    }
}
