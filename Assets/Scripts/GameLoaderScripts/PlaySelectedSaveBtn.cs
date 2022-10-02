using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySelectedSaveBtn : MonoBehaviour
{
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Play);
    }

    void Play()
    {

        SceneManager.LoadScene(2);
    }
}
