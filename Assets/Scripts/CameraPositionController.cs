using UnityEngine;

public class CameraPositionController : MonoBehaviour
{
    private Vector2 lastPositionMouse = new Vector2(0, 0);
    [SerializeField] public float sense = 10f;
    [SerializeField] public float scaleSense = 100f;

    // constants
    private float deltaFactor = 1000f;
    private float max_y_value = 10;
    private float mix_y_value = 5;

    void Update()
    {
        MoveCamera();
        ScaleCamera();
    }


    void MoveCamera()
    {
        if (Input.GetMouseButton(2))
        {
            if (lastPositionMouse != new Vector2(0, 0))
            {
                transform.position += new Vector3((lastPositionMouse.x - Input.mousePosition.x), 0, (lastPositionMouse.y - Input.mousePosition.y)) * sense / deltaFactor;
            }
            lastPositionMouse = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(2))
        {
            lastPositionMouse = new Vector2(0, 0);
        }
    }


    void ScaleCamera()
    {
        float mouseScrollDelta = Input.mouseScrollDelta.y;

        float y_delta = transform.position.y - mouseScrollDelta * Mathf.Cos(transform.rotation.x) * scaleSense / deltaFactor;
        float z_delta = transform.position.z + mouseScrollDelta * Mathf.Sin(transform.rotation.x) * scaleSense / deltaFactor;

        if (y_delta >= mix_y_value && y_delta <= max_y_value)
        {
            transform.position = new Vector3(transform.position.x, y_delta, z_delta);
        }
    }
}
