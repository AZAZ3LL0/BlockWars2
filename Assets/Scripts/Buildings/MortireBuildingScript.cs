using UnityEngine;

public class MortireBuildingScript : BuildingAbstract
{
    public int rangeOfFire = 2;
    public int costOfFireGold = 0;
    public int costOfFireActions = 3;
    public int damage = 2;

    private int doubledAndSquaredRange;
    public void Awake()
    {
        transform.gameObject.GetComponent<Healths>().SetUp(2);
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
                        cam.GetComponent<ProjectileFabric>().MortireProjectileInstantiate(index - GetComponent<BuildingStruct>().index, transform.position + Vector3.up);
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
