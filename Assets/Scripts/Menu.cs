using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] MondaiManager _mondaiManager;

    [SerializeField] GameObject _menuPanel;

    public int mondaiCount;
    public float interval;//�����Ԋu�i1�`�P�O���j
    public float duration;//��ʂɉf�鎞�ԁi�T�`�Q�O���j
    public int level;//���i�P�`�R�j

    public int mode;//�o�������i�Q�p�^�[���j


    //�ǂݏグ����ONOFF
    //�o�����@
    //

    //�Ղ̌X��

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
