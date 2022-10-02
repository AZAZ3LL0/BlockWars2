using UnityEngine;
using UnityEngine.UI;

public class HideBtnBuildings : MonoBehaviour
{
    public Canvas canv;
    public GameObject building;
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(building.GetComponent<BuildingAbstract>().HideUI);
    }
}
