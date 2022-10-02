public static class SettingsParams
{
    public static float musicPower = 0;
    public static float fxPower = 0;

    public static bool fulscreen = true;
    public static int[] resolution = new int[2] {1920, 1080};

    public static bool isFPScounterActive = false;
    public static int fpsMax = 144;

    public static bool isDebugHudActive = false;

    public static string current_save_name = "defaultData.json";


    public static void ChangeMap(string NameOfMap)
    {
        if (NameOfMap != null)
        {
            current_save_name = NameOfMap;
        }
    }
}
