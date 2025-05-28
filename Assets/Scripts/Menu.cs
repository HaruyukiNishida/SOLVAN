using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] MondaiManager _mondaiManager;

    [SerializeField] GameObject _menuPanel;

    public int mondaiCount;
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
        mondaiCount = 10;
        interval = 5;
        duration = 5;
        level = 1;
        
        mode = 0;

    }

    public void UpdateMenu()
    {
        
    }




    public void Toggle()
    {
        _menuPanel.gameObject.SetActive(!_menuPanel.gameObject.activeSelf);

        _btnManager.BtnIntaractable(!_menuPanel.gameObject.activeSelf);

        _mondaiManager.MondaiDestroy();
    }

    public void Demo()
    {
        Debug.LogWarning("D E M O");

        _mondaiManager.MondaiDestroy();

        _mondaiManager.MondaiInit();

    }

}
