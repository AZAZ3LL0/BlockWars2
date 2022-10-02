using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Texture2D default_cursor;
    [SerializeField] private Texture2D move_cursor;
    [SerializeField] private Texture2D fire_cursor;

    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;
    private CameraController main;

    private void Start()
    {
        main = GetComponent<CameraController>();
    }

    private void Update()
    {
        if (main.fireMouse)
        {
            Cursor.SetCursor(fire_cursor, hotSpot, cursorMode);
            return;
        }
        
        if (Input.GetMouseButton(2))
        {
            Cursor.SetCursor(move_cursor, hotSpot, cursorMode);
            return;
        }

        Cursor.SetCursor(default_cursor, hotSpot, cursorMode);
    }
}
