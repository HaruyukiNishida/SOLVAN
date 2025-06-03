using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    [SerializeField] TMP_Text _startBtnTxt;

    private Button _btn;
    private GamingColor _gamingColor;

    void Start()
    {
        _btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        _startBtnTxt.enabled = _btn.interactable;

        _startBtnTxt.color = GamingColor.instance.GetGamingColor();

    }



}
