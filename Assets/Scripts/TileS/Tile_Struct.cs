using UnityEngine;

public class Tile_Struct : MonoBehaviour
{
    public Commands command_attachment;
    public TileType tile_type;
    public bool with_build = false;
    public Vector2Int index;

    public GameObject LeftBorder;
    public GameObject RightBorder;
    public GameObject UpBorder;
    public GameObject DownBorder;
}
