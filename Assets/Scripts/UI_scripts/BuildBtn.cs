using UnityEngine;
using UnityEngine.UI;

public class BuildBtn : MonoBehaviour
{
    [SerializeField] private BuildingsType type_of_building;
    public GameObject tile;
    [SerializeField] private GameObject main;
    public int cost_gold;
    public int cost_act;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Build);
        main = GameObject.Find("Camera");
    }

    private void Build()
    {
        if (main.GetComponent<CameraController>().PossibilityToSpend(cost_gold, cost_act))
        {
            main.GetComponent<BuildFabric>().create_build(type_of_building, tile.GetComponent<Tile_Struct>().index, main.GetComponent<CameraController>().GetTurn(), 0);
            main.GetComponent<CameraController>().Spend(cost_gold, cost_act);
        }
        tile.GetComponent<TileScript>().HideUI();
    }
}
