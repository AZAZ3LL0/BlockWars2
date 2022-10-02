using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    [SerializeField] private GameObject smoke_system;
    private ParticleSystem smoke;

    private void Start()
    {
        smoke = smoke_system.GetComponent<ParticleSystem>();
    }


    public void PlayOneShotSmoke()
    {
        if (smoke != null)
        {
            smoke.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            smoke.Play();
        }
    }
}
