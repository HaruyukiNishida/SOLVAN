using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] MondaiManager _mondaiManager;

    [SerializeField] GameObject _menuPanel;
    [SerializeField] Title _title;

    public int mondaiCount;
    public float interval;//発生間隔
    public float duration;//画面に映る時間
    public int level;//桁

    public int mode;//出現方式（２パターン）

    public float interval_min = 0.5f;
    public float interval_max = 20f;
    public float duration_min = 0.5f;
    public float duration_max = 20f;

    private bool active;
    //読み上げ音声ONOFF


    private void Awake()
    {
        active = false;
        _menuPanel.SetActive(false);
    }

    void Start()
    {
        mondaiCount = 5;
        interval = 10.0f;
        duration = 10.0f;
        level = 0;

        mode = 1;

    }

    public void Toggle()
    {
        active = !active;

      //  _menuPanel.gameObject.SetActive(!_menuPanel.gameObject.activeSelf);
        _menuPanel.gameObject.SetActive(active);

        _btnManager.BtnIntaractableStartAndUndo(!active);

        _title.LogoDisp(!active);

        _mondaiManager.MondaiDestroy();

        if(active) AudioManager.instance.PlaySE(TypePlaySE.WadaikoDon);
    }

    public void Demo()
    {
        Debug.LogWarning("D E M O");

        _mondaiManager.MondaiDestroy();

        _mondaiManager.MondaiManagerInit();

    }

}
