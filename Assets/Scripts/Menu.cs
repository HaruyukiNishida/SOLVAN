using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] MondaiManager _mondaiManager;

    [SerializeField] GameObject _menuPanel;

    public int mondaiCount;
    public float interval;//�����Ԋu
    public float duration;//��ʂɉf�鎞��
    public int level;//��

    public int mode;//�o�������i�Q�p�^�[���j


    //�ǂݏグ����ONOFF
    

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
