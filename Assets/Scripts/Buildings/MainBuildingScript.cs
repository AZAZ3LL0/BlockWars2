public class MainBuildingScript : BuildingAbstract
{
    public void Awake()
    {
        transform.gameObject.GetComponent<Healths>().SetUp(10);
        gold_produce = 0;
        actions_produce = 3;
    }

    public override void OnTurnEnd()
    {
        cam.GetComponent<CameraController>().AddValueToCounters(gold_produce, actions_produce);
    }
}
