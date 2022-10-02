public class TownBuildingScript : BuildingAbstract
{
    public void Awake()
    {
        transform.gameObject.GetComponent<Healths>().SetUp(4);
        gold_produce = 0;
        actions_produce = 2;
    }

    public override void OnTurnEnd()
    {
        cam.GetComponent<CameraController>().AddValueToCounters(gold_produce, actions_produce);
    }
}
