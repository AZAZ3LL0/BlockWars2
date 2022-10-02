using UnityEngine;
using UnityEngine.UI;

public class AttachBtn : MonoBehaviour
{

    public GameObject tile;
    [SerializeField] private GameObject main;
    public int cost_gold = 0;
    public int cost_act = 1;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Attach);
        main = GameObject.Find("Camera");
    }

    private void Attach()
    {
        if (main.GetComponent<CameraController>().PossibilityToSpend(cost_gold, cost_act) && ClosenessCheck())
        {
            tile.GetComponent<Tile_Struct>().command_attachment = main.GetComponent<CameraController>().curent_comand;
            main.GetComponent<CameraController>().Spend(cost_gold, cost_act);

            main.GetComponent<TileManager>().RefreshEndMesh();
        }
        tile.GetComponent<TileScript>().HideUI();

    }

    private bool ClosenessCheck()
    {
        Tile_Struct tilestruct = tile.GetComponent<Tile_Struct>();
        TileManager tilemanager = main.GetComponent<TileManager>();
        CameraController camcontroller = main.GetComponent<CameraController>();

        if (tilestruct.index.y > 0 && tilemanager.GetAttFromIndex(tilestruct.index + Vector2Int.down) == camcontroller.GetTurn())
        {
            return true;
        }
        if (tilestruct.index.y < 11 && tilemanager.GetAttFromIndex(tilestruct.index + Vector2Int.up) == camcontroller.GetTurn())
        {
            return true;
        }
        if (tilestruct.index.x > 0 && tilemanager.GetAttFromIndex(tilestruct.index + Vector2Int.left) == camcontroller.GetTurn())
        {
            return true;
        }
        if (tilestruct.index.x < 11 && tilemanager.GetAttFromIndex(tilestruct.index + Vector2Int.right) == camcontroller.GetTurn())
        {
            return true;
        }
        return false;
    }
}
