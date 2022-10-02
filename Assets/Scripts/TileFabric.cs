using UnityEngine;


public class TileFabric : MonoBehaviour
{
    [SerializeField] private GameObject tile_default;
    [SerializeField] private GameObject tile_river;

    [SerializeField] private GameObject tile_forest_1;
    [SerializeField] private GameObject tile_forest_2;
    [SerializeField] private GameObject tile_forest_3;

    public GameObject create_tile(TileType type, Vector2Int id, Commands att)
    {
        GameObject tile;
        switch (type)
        {
            case TileType.Default:
                tile = Instantiate(tile_default, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            case TileType.River:
                tile = Instantiate(tile_river, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            case TileType.Forest:
                int id_of_forest = Random.Range(0, 3);
                switch (id_of_forest)
                {
                    case 0:
                        tile = Instantiate(tile_forest_1, new Vector3(id.x, 0, id.y), Quaternion.identity);
                        break;
                    case 1:
                        tile = Instantiate(tile_forest_2, new Vector3(id.x, 0, id.y), Quaternion.identity);
                        break;
                    case 2:
                        tile = Instantiate(tile_forest_3, new Vector3(id.x, 0, id.y), Quaternion.identity);
                        break;
                    default:
                        return null;
                }
                break;
            default:
                Debug.Log("ERROR type incorrect: " + type);
                return null;
        }
        tile.GetComponent<Tile_Struct>().index = id;
        tile.GetComponent<Tile_Struct>().command_attachment = att;
        return tile;
    }
}

