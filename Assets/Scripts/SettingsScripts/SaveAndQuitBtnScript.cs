using System.Collections;
using System.Collections.Generic;
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

    }
}
