using UnityEngine;

public class CannonBuildingScript : BuildingAbstract
{
    public int rangeOfFire = 1;
    public int costOfFireGold = 0;
    public int costOfFireActions = 1;
    public int damage = 1;

    public float timeofanimation = 0.5f;

    private int doubledAndSquaredRange;
    public void Awake()
    {
        transform.gameObject.GetComponent<Healths>().SetUp(3);
        gold_produce = 0;
        actions_produce = 0;

        doubledAndSquaredRange = 2 * rangeOfFire * rangeOfFire;
    }

    public override void Fire(Vector2Int index)
    {
        if (cam.GetComponent<CameraController>().PossibilityToSpend(costOfFireGold, costOfFireActions))
        {
            if ((index - GetComponent<BuildingStruct>().index).sqrMagnitude <= doubledAndSquaredRange)
            {
                foreach (GameObject building in cam.GetComponent<CameraController>().buildings)
                {
                    if (building.GetComponent<BuildingStruct>().index == index)
                    {
                        GetComponent<SmokeController>().PlayOneShotSmoke();
                        cam.GetComponent<ProjectileFabric>().CannonProjectileInstantiate(index - GetComponent<BuildingStruct>().index, transform.position + Vector3.up, timeofanimation);
                        cam.GetComponent<CameraController>().Spend(costOfFireGold, costOfFireActions);
                        building.GetComponent<Healths>().Damage(damage);
                        return;
                    }
                }
                Debug.Log("На этом месте нет построек");
            }
            else { Debug.Log("Слишком далеко"); }
        }
        else { Debug.Log("Недостаточно действий"); }
    }
}
