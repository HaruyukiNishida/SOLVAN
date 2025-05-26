using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    [SerializeField] GameObject _startBtn;
    [SerializeField] GameObject _menuBtn;
    [SerializeField] GameObject _undoBtn;
    [SerializeField] GameObject _pauseBtn;


    private void Awake()
    {
        BtnDisp(false);
    }

    public void BtnDisp(bool active)
    {
        _startBtn.SetActive(!active);
        _menuBtn.SetActive(!active);
        _undoBtn.SetActive(active);
        _pauseBtn.SetActive(active);
    }

    public void BtnIntaractable(bool interactable)
    {
        _startBtn.GetComponent<Button>().interactable = interactable;
        _undoBtn.GetComponent<Button>().interactable = interactable;
    }
}
