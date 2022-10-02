using UnityEngine;
using UnityEngine.UI;

public class RepairBtn : MonoBehaviour
{
    public GameObject building;
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(building.GetComponent<BuildingAbstract>().Repare);
    }
}
