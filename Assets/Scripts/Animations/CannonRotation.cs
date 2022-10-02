using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] private GameObject CannonTop;
    [SerializeField] private GameObject Main;

    private Vector2 direction;
    private float animationTime;
    private Quaternion rotation;
    private Quaternion rotation_start;
    private CameraController controller;

    private void Start()
    {
        controller = Main.GetComponent<CameraController>();
        rotation_start = CannonTop.transform.rotation;
    }

    public void StartAnimation(Vector2 direction, float animationTime)
    {
        this.direction = direction;

        //rotation.eulerAngles = new Quaternion(rotation_start.eulerAngles.x, , rotation_start.eulerAngles.z);

        this.animationTime = animationTime;
        StartCoroutine(nameof(RotateInDirection));
    }

    public IEnumerator RotateInDirection()
    {
        for (float i = 0; i < animationTime; i += Time.deltaTime)
        {
            //CannonTop.transform.rotation = Quaternion.Lerp();
            yield return null;
        }
    }
}
