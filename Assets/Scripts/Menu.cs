using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] GameObject _menuPanel;

    public float interval;//�����Ԋu�i1�`�P�O���j
    public float duration;//��ʂɉf�鎞�ԁi�T�`�Q�O���j
    public int level;//���i�P�`�R�j

    public int mode;//�o�������i�Q�p�^�[���j


    //�ǂݏグ����ONOFF
    //�o�����@
    //

    //�Ղ̌X��

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

        _gameDirector.BtnIntaractable(!_menuPanel.gameObject.activeSelf);
    }



}
