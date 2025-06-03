using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] MondaiManager _mondaiManager;

    [SerializeField] GameObject _menuPanel;
    [SerializeField] Title _title;

    public int mondaiCount;
    public float interval;//�����Ԋu
    public float duration;//��ʂɉf�鎞��
    public int level;//��

    public int mode;//�o�������i�Q�p�^�[���j

    private bool active;
    //�ǂݏグ����ONOFF


    private void Awake()
    {
        active = false;
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
        active = !active;

      //  _menuPanel.gameObject.SetActive(!_menuPanel.gameObject.activeSelf);
        _menuPanel.gameObject.SetActive(active);

        _btnManager.BtnIntaractableStartAndUndo(!active);

        _title.LogoDisp(!active);

        _mondaiManager.MondaiDestroy();
    }

    public void Demo()
    {
        Debug.LogWarning("D E M O");

        _mondaiManager.MondaiDestroy();

        _mondaiManager.MondaiInit();

    }

}
