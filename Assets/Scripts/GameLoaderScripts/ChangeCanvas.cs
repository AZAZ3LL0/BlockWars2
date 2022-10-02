using UnityEngine;
using UnityEngine.UI;

public enum FramesCanvas
{
    LoadFrame,
    PresetsFrame,
    procedualFrame
}

public class ChangeCanvas : MonoBehaviour
{
    [SerializeField] private FramesCanvas thisFrameis;

    [SerializeField] private GameObject canvasLoadFrame;
    [SerializeField] private GameObject canvasPresetsFrame;
    [SerializeField] private GameObject canvasprocedualFrame;
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeCnvs);

        canvasLoadFrame.GetComponent<Canvas>().enabled = true;
        canvasPresetsFrame.GetComponent<Canvas>().enabled = false;
        canvasprocedualFrame.GetComponent<Canvas>().enabled = false;
    }

    private void ChangeCnvs()
    {
        if (thisFrameis == FramesCanvas.LoadFrame)
        {
            canvasLoadFrame.GetComponent<Canvas>().enabled = true;
            canvasPresetsFrame.GetComponent<Canvas>().enabled = false;
            canvasprocedualFrame.GetComponent<Canvas>().enabled = false;
        }
        if (thisFrameis == FramesCanvas.PresetsFrame)
        {
            canvasLoadFrame.GetComponent<Canvas>().enabled = false;
            canvasPresetsFrame.GetComponent<Canvas>().enabled = true;
            canvasprocedualFrame.GetComponent<Canvas>().enabled = false;
        }
        if (thisFrameis == FramesCanvas.procedualFrame)
        {
            canvasLoadFrame.GetComponent<Canvas>().enabled = false;
            canvasPresetsFrame.GetComponent<Canvas>().enabled = false;
            canvasprocedualFrame.GetComponent<Canvas>().enabled = true;
        }
    }
}
