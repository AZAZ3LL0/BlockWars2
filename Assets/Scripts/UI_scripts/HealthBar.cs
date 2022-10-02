using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float progress = 1f;

    public void SetHealths(int healths, int max_healths)
    {
        progress = 1.0f * healths / max_healths;
    }

    void Update()
    {
        transform.gameObject.GetComponent<Image>().fillAmount = progress;
    }
}
