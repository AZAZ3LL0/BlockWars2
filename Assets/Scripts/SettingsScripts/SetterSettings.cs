using UnityEngine;

static public class SetterSettings
{
    static public void SetSettings()
    {
        // set resolution and screen mod
        Application.targetFrameRate = SettingsParams.fpsMax;
        QualitySettings.vSyncCount = System.Convert.ToInt32(SettingsParams.vsync);
        if (SettingsParams.fulscreen)
        {
            Screen.SetResolution(SettingsParams.resolution[0], SettingsParams.resolution[1], FullScreenMode.FullScreenWindow);
        }
        else
        {
            Screen.SetResolution(SettingsParams.resolution[0], SettingsParams.resolution[1], FullScreenMode.Windowed);
        }

        // set sounds values
        // some staff....
    }
}
