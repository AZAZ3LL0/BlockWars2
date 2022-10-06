using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndQuitBtnScript : MonoBehaviour
{
    [SerializeField] private GameObject FullscreenCB;
    [SerializeField] private GameObject MusicSlider;
    [SerializeField] private GameObject FXSlider;
    [SerializeField] private GameObject FPSCounter;
    [SerializeField] private GameObject DebugHUD;
    [SerializeField] private GameObject MaxFps;
    [SerializeField] private GameObject WidthIF;
    [SerializeField] private GameObject HeightIF;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SaveSettings);
    }


    private void SaveSettings()
    {
        // save settings in static class
        SettingsParams.fulscreen = FullscreenCB.GetComponent<Toggle>().isOn;
        SettingsParams.isFPScounterActive = FPSCounter.GetComponent<Toggle>().isOn;
        SettingsParams.isDebugHudActive = DebugHUD.GetComponent<Toggle>().isOn;

        SettingsParams.musicPower = MusicSlider.GetComponent<Slider>().value;
        SettingsParams.fxPower = FXSlider.GetComponent<Slider>().value;

        if (MaxFps.GetComponent<Text>().text != "")
        {
            SettingsParams.fpsMax = System.Convert.ToInt32(MaxFps.GetComponent<Text>().text);
        }
        if (WidthIF.GetComponent<Text>().text != "" && HeightIF.GetComponent<Text>().text != "")
        {
            SettingsParams.resolution = new int[2] { System.Convert.ToInt32(WidthIF.GetComponent<Text>().text), System.Convert.ToInt32(HeightIF.GetComponent<Text>().text) };
        }

        // set settings
        SetterSettings.SetSettings();
        // quit in main menu
        SceneManager.LoadScene(0);
    }
}
