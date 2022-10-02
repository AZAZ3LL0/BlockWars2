using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class QuitBtnScript : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Play);
    }

    public void Play()
    {
        // quit in main menu
        SceneManager.LoadScene(0);
    }
}
