using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    public GameObject TileDefault;
    public GameObject TileRiver;
    public GameObject TileForest;

    private List<GameObject> Tileset;

    private Vector2Int size = new Vector2Int(10, 10);

    private void Start()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Instantiate(TileDefault, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
    }

    public Vector3 MeshToGlobalCoordinates(Vector2Int coords)
    {
        return new Vector3(coords.x, 0, coords.y);
    }
}
