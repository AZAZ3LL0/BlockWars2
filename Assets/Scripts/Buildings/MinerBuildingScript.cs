public class MinerBuildingScript : BuildingAbstract
{
    public void Awake()
    {
        transform.gameObject.GetComponent<Healths>().SetUp(3);
        gold_produce = 5;
        actions_produce = -1;
    }

    public override void OnTurnEnd()
    {
        cam.GetComponent<CameraController>().AddValueToCounters(gold_produce, actions_produce);
    }
}
