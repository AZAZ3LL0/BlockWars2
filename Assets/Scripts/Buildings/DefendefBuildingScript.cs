using UnityEngine;

public class DefendefBuildingScript : BuildingAbstract
{
    /* 
        �� ����� ���� �����, �������� � ����� � ������������� ����� 
        ������� ����� - ������ ���� + ����� ���� �����, ������� ������ 
        � ������� 1 ������ ����� ������ �� 1 �� ������ ��� ��������
     */

    public int rangeOfHeal = 1;
    private int doubledAndSquaredRange;
    public int heal = 1;

    public void Awake()
    {
        transform.gameObject.GetComponent<Healths>().SetUp(3);
        gold_produce = -4;
        actions_produce = 0;

        doubledAndSquaredRange = 2 * rangeOfHeal * rangeOfHeal;
    }


    public override void OnTurnEnd()
    {
        if (cam.GetComponent<CameraController>().PossibilityToSpend(-gold_produce, -actions_produce))
        {
            cam.GetComponent<CameraController>().AddValueToCounters(gold_produce, actions_produce);

            foreach (GameObject building in cam.GetComponent<CameraController>().buildings)
            {
                if (building.GetComponent<BuildingStruct>().command_attachment == cam.GetComponent<CameraController>().GetTurn())
                {
                    if ((building.GetComponent<BuildingStruct>().index - GetComponent<BuildingStruct>().index).sqrMagnitude <= doubledAndSquaredRange)
                    {
                        building.GetComponent<Healths>().Heal(heal);
                    }
                }
            }
        }
    }
}
