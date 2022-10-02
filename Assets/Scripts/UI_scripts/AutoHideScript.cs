using UnityEngine;

public class AutoHideScript : MonoBehaviour
{
    public Canvas main;
    public Canvas att;
    public Canvas bui;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && GetComponent<Canvas>().enabled)
        {
            att.enabled = false;
            bui.enabled = false;
            main.enabled = false;
        }
    }
}
