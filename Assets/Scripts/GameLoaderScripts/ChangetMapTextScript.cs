using UnityEngine;
using UnityEngine.UI;

public class ChangetMapTextScript : MonoBehaviour
{
    
    void Update()
    {
        GetComponent<Text>().text = SettingsParams.current_save_name;
    }
}
