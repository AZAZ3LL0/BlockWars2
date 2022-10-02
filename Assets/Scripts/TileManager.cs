using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private CameraController cam_control;
    [SerializeField] private Material RedGlow;
    [SerializeField] private Material BlueGlow;

    private GameObject[] tiles;

    private int[] boardTopology;

    private void Start()
    {
        boardTopology = cam_control.boardTopology;
        tiles = cam_control.tiles;
        RefreshEndMesh();
    }

    public GameObject GetTileFromIndex(Vector2Int index)
    {
        foreach (GameObject tile in tiles)
        {
            if (tile.GetComponent<Tile_Struct>().index == index)
            {
                return tile;
            }
        }
        return null;
    }

    public Commands GetAttFromIndex(Vector2Int index)
    {
        GameObject tile = GetTileFromIndex(index);
        return tile.GetComponent<Tile_Struct>().command_attachment;
    }

    public bool WithBuildFromIndex(Vector2Int index)
    {
        GameObject tile = GetTileFromIndex(index);
        return tile.GetComponent<Tile_Struct>().with_build;
    }

    public TileType GetTypeFromIndex(Vector2Int index)
    {
        GameObject tile = GetTileFromIndex(index);
        return tile.GetComponent<Tile_Struct>().tile_type;
    }

    public void RefreshEndMesh()
    {
        foreach (GameObject tile in tiles)
        {
            Tile_Struct ts = tile.GetComponent<Tile_Struct>();

            if (ts.tile_type != TileType.River)
            {
                if (ts.command_attachment == Commands.Empty)
                {
                    ts.LeftBorder.SetActive(false);
                    ts.RightBorder.SetActive(false);
                    ts.UpBorder.SetActive(false);
                    ts.DownBorder.SetActive(false);
                }
                else
                {
                    if (ts.index.y < boardTopology[1] - 1 && ts.command_attachment == GetAttFromIndex(ts.index + Vector2Int.up))
                    {
                        ts.UpBorder.SetActive(false);
                    }
                    else
                    {
                        ts.UpBorder.SetActive(true);
                        SetMaterialToBorder(ts.UpBorder, ts.command_attachment);
                    }
                    if (ts.index.y > 0 && ts.command_attachment == GetAttFromIndex(ts.index + Vector2Int.down))
                    {
                        ts.DownBorder.SetActive(false);
                    }
                    else
                    {
                        ts.DownBorder.SetActive(true);
                        SetMaterialToBorder(ts.DownBorder, ts.command_attachment);
                    }
                    if (ts.index.x > 0 && ts.command_attachment == GetAttFromIndex(ts.index + Vector2Int.left))
                    {
                        ts.LeftBorder.SetActive(false);
                    }
                    else
                    {
                        ts.LeftBorder.SetActive(true);
                        SetMaterialToBorder(ts.LeftBorder, ts.command_attachment);
                    }
                    if (ts.index.x < boardTopology[0] - 1 && ts.command_attachment == GetAttFromIndex(ts.index + Vector2Int.right))
                    {
                        ts.RightBorder.SetActive(false);
                    }
                    else
                    {
                        ts.RightBorder.SetActive(true);
                        SetMaterialToBorder(ts.RightBorder, ts.command_attachment);
                    }
                }
            }
        }
    }

    private void SetMaterialToBorder(GameObject border, Commands attachment)
    {
        if (attachment == Commands.Red)
        {
            border.GetComponentInChildren<Renderer>().material = RedGlow;
        }
        else if (attachment == Commands.Blue)
        {
            border.GetComponentInChildren<Renderer>().material = BlueGlow;
        }
        else
        {
            return;
        }
    }
}
