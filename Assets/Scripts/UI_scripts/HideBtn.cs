using UnityEngine;
using UnityEngine.UI;

public class HideBtn : MonoBehaviour
{
    public Canvas canv;
    public GameObject tile;
    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(tile.GetComponent<TileScript>().HideUI);
    }
}
