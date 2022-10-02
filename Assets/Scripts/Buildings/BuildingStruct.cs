using UnityEngine;

public class BuildingStruct : MonoBehaviour
{
    public BuildingsType building_type;
    public Commands command_attachment;
    public Vector2Int index;


    public void SetCommandAttachment(Commands co_at)
    {
        command_attachment = co_at;
    }
}
