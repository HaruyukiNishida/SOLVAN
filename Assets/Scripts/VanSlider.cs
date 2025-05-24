using UnityEngine;
using UnityEngine.UI;

public class VanSlider : MonoBehaviour
{
    [SerializeField] GameObject _panel;

    public void PanelOn()
    {
        _panel.SetActive(true);
    }

    public void PanelOff()
    {
        _panel.SetActive(false);
    }
}
