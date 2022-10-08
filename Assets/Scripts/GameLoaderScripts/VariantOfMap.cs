using UnityEngine;
using UnityEngine.UI;

public class VariantOfMap : MonoBehaviour
{
    [SerializeField] private string pathToMap;
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeMap);
    }

    public void SetUp(string pathToMap)
    {
        this.pathToMap = pathToMap;

        string[] splittedfilename = pathToMap.Split('/');
        GetComponentInChildren<Text>().text = splittedfilename[splittedfilename.Length - 1].Split('.')[0];
    }

    private void ChangeMap()
    {
        if (pathToMap != null)
        {
            SettingsParams.ChangeMap(pathToMap);
        }
    }
}
