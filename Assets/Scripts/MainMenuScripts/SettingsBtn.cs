using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsBtn : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Settings);
    }

    public void Settings()
    {
        SceneManager.LoadScene(3);
    }
}
