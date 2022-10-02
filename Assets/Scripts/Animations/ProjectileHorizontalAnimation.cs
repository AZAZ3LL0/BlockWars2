using System.Collections;
using UnityEngine;

public class ProjectileHorizontalAnimation : MonoBehaviour
{
    [SerializeField] private float animationTime = 2f;
    [SerializeField] public Vector2 direction = Vector2.zero;

    private Vector3 nullDot;

    public void StartAnimation(Vector2 direction)
    {
        nullDot = transform.position;
        this.direction = direction;
        StartCoroutine(nameof(HorizontalMove));
    }

    public void StartAnimation(Vector2 direction, float animationTime)
    {
        nullDot = transform.position;
        this.direction = direction;
        this.animationTime = animationTime;
        StartCoroutine(nameof(HorizontalMove));
    }

    IEnumerator HorizontalMove()
    {
        for (float i = 0; i < animationTime; i += Time.deltaTime)
        {
            transform.position = new Vector3(Mathf.Lerp(nullDot.x, nullDot.x + direction.x, i / animationTime), transform.position.y, Mathf.Lerp(nullDot.z, nullDot.z + direction.y, i / animationTime));
            yield return null;
        }
    }
}
