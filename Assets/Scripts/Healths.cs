using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healths : MonoBehaviour
{
    [SerializeField] private int healths;
    [SerializeField] private int max_healths;

    [SerializeField] private HealthBar HpBar;


    public void SetUp(int max_heal)
    {
        healths = max_heal;
        max_healths = max_heal;
    }

    public void Start()
    {
        HpBar = transform.gameObject.GetComponentInChildren<HealthBar>();
    }

    public int GetHealths()
    {
        return healths;
    }

    public int GetMaxHealths()
    {
        return max_healths;
    }

    public bool IsMaxHealed()
    {
        return healths >= max_healths;
    }

    public void Damage(int damage)
    {
        if (damage <= 0) {
            return;
        }
        else if (damage >= healths)
        {
            healths = 0;
        }
        else
        {
            healths -= damage;
        }
    }

    public void Heal(int heal)
    {
        if (heal <= 0)
        {
            return;
        }
        else if (heal + healths >= max_healths)
        {
            healths = max_healths;
        }
        else
        {
            healths += heal;
        }
    }

    public void SetHealths(int current_healths)
    {
        if (current_healths > max_healths)
        {
            healths = max_healths;
        }
        else
        {
            healths = current_healths;
        }
    }

    public void Update()
    {
        if (healths <= 0)
        {
            GetComponent<BuildingAbstract>().DestroyThis();
        }
        HpBar.SetHealths(healths, max_healths);
    }
}
