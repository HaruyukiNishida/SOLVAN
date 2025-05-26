using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] GameObject _menuPanel;

    public float interval;//”­¶ŠÔŠui1`‚P‚O‚†j
    public float duration;//‰æ–Ê‚É‰f‚éŠÔi‚T`‚Q‚O‚†j
    public int level;//Œ…i‚P`‚Rj

    public int mode;//oŒ»•û®i‚Qƒpƒ^[ƒ“j


    //“Ç‚İã‚°‰¹ºONOFF
    //oŒ»•û–@
    //

    //”Õ‚ÌŒX‚«

    private void Awake()
    {
        _menuPanel.SetActive(false);
    }

    void Start()
    {

        interval = 10;
        level = 1;
        duration = 8;
        mode = 1;
        Debug.Log($"{interval} {level} {duration} {mode}");

    }



    public void Toggle()
    {
        _menuPanel.gameObject.SetActive(!_menuPanel.gameObject.activeSelf);

        _btnManager.BtnIntaractable(!_menuPanel.gameObject.activeSelf);
    }

    public void Demo()
    {
        Debug.LogWarning("D E M O");

    }

}
