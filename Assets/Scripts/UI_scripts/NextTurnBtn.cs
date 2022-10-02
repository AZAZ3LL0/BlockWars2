using UnityEngine;
using UnityEngine.UI;

public class NextTurnBtn : MonoBehaviour
{
    public GameObject main;

	public Text turn_txt;

	void Start()
	{
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(main.GetComponent<CameraController>().ToggleTurn);
	}
}
