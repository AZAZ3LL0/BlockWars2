using UnityEngine;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(QuitFromGame);
    }

    void QuitFromGame()
    {
        Application.Quit();
    }
}
