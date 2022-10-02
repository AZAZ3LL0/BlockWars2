using UnityEngine;
using UnityEngine.UI;

public class VariantOfMap : MonoBehaviour
{
    [SerializeField] private string pathToMap;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeMap);
    }

    public void SetUp(string pathToMap)
    {
        this.pathToMap = pathToMap;
        GetComponentInChildren<Text>().text = pathToMap;
    }

    private void ChangeMap()
    {
        if (pathToMap != null)
        {
            SettingsParams.ChangeMap(pathToMap);
        }
    }
}
