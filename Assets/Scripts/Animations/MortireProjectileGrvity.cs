using System.Collections;
using UnityEngine;

public class MortireProjectileGrvity : MonoBehaviour
{
    [SerializeField] private float animationTime = 2;
    [SerializeField] private float heightOfProjectile = 1;

    private Vector3 nullDot;
    void Start()
    {
        nullDot = transform.position;
        StartCoroutine(nameof(GravityMove));
    }

    IEnumerator GravityMove()
    {
        for (float i = 0; i < animationTime; i += Time.deltaTime)
        {

            transform.position = new Vector3(transform.position.x, nullDot.y + Parabola(i), transform.position.z);
            yield return null;
        }
    }


    private float Parabola(float x)
    {
        return heightOfProjectile - (x - animationTime / 2) * (x - animationTime / 2);
    }
}
