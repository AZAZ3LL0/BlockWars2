using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class VariantsFabric : MonoBehaviour
{
    [SerializeField] private string PATH_TO_SAVES;
    private string savedgame = "\\savedgames\\";
    private string presets = "\\presets\\";

    [SerializeField] private GameObject MapToChangeExemplare;

    [SerializeField] private GameObject PresetContent;
    [SerializeField] private GameObject SavedContent;

    public string[] files;
    public string[] loads;
    void Start()
    {
        files = Directory.GetFiles(PATH_TO_SAVES + presets);
        loads = Directory.GetFiles(PATH_TO_SAVES + savedgame);
        CreateContent();
    }

    public void CreateContent()
    {
        // Presets SetUp
        int temp_height = 525;
        int delta = -75;
        foreach (string file in files)
        {
            //Debug.Log(file.Split('\\')[file.Split('\\').Length - 1]);
            //Debug.Log(file);
            GameObject contentBTN = Instantiate(MapToChangeExemplare, new Vector3Int(650, temp_height, 0), Quaternion.identity, PresetContent.transform);
            contentBTN.GetComponentInChildren<VariantOfMap>().SetUp(presets + file.Split('\\')[file.Split('\\').Length - 1]);

            temp_height += delta;

        }

        // Loads setup
        temp_height = 525;
        foreach (string file in loads)
        {
            //Debug.Log(file.Split('\\')[file.Split('\\').Length - 1]);
            //Debug.Log(file);
            GameObject contentBTN = Instantiate(MapToChangeExemplare, new Vector3Int(650, temp_height, 0), Quaternion.identity, SavedContent.transform);
            contentBTN.GetComponentInChildren<VariantOfMap>().SetUp(savedgame + file.Split('\\')[file.Split('\\').Length - 1]);

            temp_height += delta;

        }
    }
}
