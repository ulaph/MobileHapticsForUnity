# MobileHapticsForUnity
Haptics Plugin for Unity that runs on iOS and Android.

# Install with UPM
Add package from git URL at PackageManager window.

`https://github.com/ulaph/MobileHapticsForUnity.git?path=Assets/MobileHapticsForUnity`

or add

`"com.ulaph.mobile-haptics-for-unity": "https://github.com/ulaph/MobileHapticsForUnity.git?path=Assets/MobileHapticsForUnity"`

to `Packages/manifest.json`

# Usage
Please choose from **Light, Medium, Heavy** impact feedback style.
```c#
using MobileHapticsForUnity;

Haptics.Impact(ImpactFeedbackStyle.Light);
```
