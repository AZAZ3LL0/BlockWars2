using System.Collections;
using UnityEngine;

public class ProjectileCleaner : MonoBehaviour
{
    [SerializeField] private float animationTime = 2f;
    public void StartAnimation(float animationTime)
    {
        this.animationTime = animationTime;
        StartCoroutine(nameof(HorizontalMove));
    }

    public void StartAnimation()
    {
        StartCoroutine(nameof(HorizontalMove));
    }

    IEnumerator HorizontalMove()
    {
        yield return new WaitForSeconds(animationTime);
        Destroy(this.gameObject);
    }
}
