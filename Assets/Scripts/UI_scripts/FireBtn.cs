using UnityEngine;
using UnityEngine.UI;

public class FireBtn : MonoBehaviour
{
    private GameObject cam;
    public GameObject building;
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ToggleMouseToFire);

        cam = GameObject.Find("Camera");
    }

    private void ToggleMouseToFire()
    {
        cam.GetComponent<CameraController>().fireMouse = true;
        cam.GetComponent<CameraController>().changedBuilding = building;
        building.GetComponent<BuildingAbstract>().HideUI();
    }
}