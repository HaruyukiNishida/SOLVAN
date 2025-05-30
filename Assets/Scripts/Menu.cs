using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] MondaiManager _mondaiManager;

    [SerializeField] GameObject _menuPanel;

    public int mondaiCount;
    public float interval;//発生間隔
    public float duration;//画面に映る時間
    public int level;//桁

    public int mode;//出現方式（２パターン）


    //読み上げ音声ONOFF
    

    private void Awake()
    {
        _menuPanel.SetActive(false);
    }

    void Start()
    {
        mondaiCount = 5;
        interval = 5.0f;
        duration = 5.0f;
        level = 1;

        mode = 1;

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
