using UnityEngine;

public class BuildFabric : MonoBehaviour
{
    [SerializeField] private GameObject MainBuilding;
    [SerializeField] private GameObject Mine;
    [SerializeField] private GameObject Town;
    [SerializeField] private GameObject Cannon;
    [SerializeField] private GameObject Mortire;
    [SerializeField] private GameObject Defender;

    public GameObject create_build(BuildingsType type, Vector2Int id, Commands att, int healths)
    {
        GameObject build;
        switch (type)
        {
            case BuildingsType.MainBuilding:
                build = Instantiate(MainBuilding, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            case BuildingsType.Mine:
                build = Instantiate(Mine, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            case BuildingsType.Town:
                build = Instantiate(Town, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            case BuildingsType.Cannon:
                build = Instantiate(Cannon, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            case BuildingsType.Mortire:
                build = Instantiate(Mortire, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            case BuildingsType.Defender:
                build = Instantiate(Defender, new Vector3(id.x, 0, id.y), Quaternion.identity);
                break;
            default:
                return null;
        }
        build.GetComponent<BuildingStruct>().index = id;
        build.GetComponent<BuildingAbstract>().SetUP(att);
        if (healths != 0)
        {
            build.GetComponent<Healths>().SetHealths(healths);
        }
        GetComponent<CameraController>().buildings.Add(build);
        return build;
    }
}
