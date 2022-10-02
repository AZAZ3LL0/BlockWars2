using UnityEngine;
using UnityEngine.UI;

public class GenerateBtnScript : MonoBehaviour
{
    [SerializeField] private GameObject NoiseObj;
    [SerializeField] private GameObject LevelOfWaterObj;
    [SerializeField] private GameObject SeedInput;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Generate);
    }

    // Update is called once per frame
    void Generate()
    {
        if (SeedInput.GetComponent<Text>().text != null)
        {
            NoiseObj.GetComponent<GenerateNoise>().SetSeed(System.Convert.ToInt32(SeedInput.GetComponent<Text>().text));
        }
        else
        {
            NoiseObj.GetComponent<GenerateNoise>().SetSeed(0);
        }
        
        NoiseObj.GetComponent<GenerateNoise>().SetPower(LevelOfWaterObj.GetComponent<Slider>().value);
        NoiseObj.GetComponent<GenerateNoise>().CalcNoise();
        SettingsParams.ChangeMap("procedualTempData.json");
    }
}
