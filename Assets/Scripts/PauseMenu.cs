using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] GameObject _pauseMenuPanel;
    [SerializeField] TMP_Text _titleText;
    [SerializeField] TMP_Text _answerText;
    [SerializeField] Image _rank;

    private bool _active = false;

    private void Start()
    {
        PauseMenuInit();
    }

    public void PauseMenuInit()
    {
        _active = false;

        _rank.gameObject.SetActive(false);


        PauseMenuTitle(false);

        _pauseMenuPanel.SetActive(false);
    }

    public void Toggle()
    {
        _active = !_active;
        Time.timeScale = (!_active) ? 1.0f : 0f;

        SetPauseMenu(_active);
    }

    void SetPauseMenu(bool active)
    {
        _pauseMenuPanel.SetActive(active);

        _btnManager.BtnIntaractableStartAndUndo(!active);

        if (active)
        {
            PauseMenuUpdate();
            AudioManager.instance.PlaySE(TypePlaySE.WadaikoDon);
        }
    }


    private void PauseMenuUpdate()
    {
        int count = _gameDirector.currentCount;
        int hit = _gameDirector.hitCount;
        int max = _gameDirector.countMax;
        int answer = _gameDirector.answer;

        _titleText.enabled = (answer == 0);
        _answerText.text = (answer == 0) ? "?????" : answer.ToString();

    }

    public void GameClear()
    {
        _btnManager.BtnIntaractablePause(false);

        _rank.gameObject.SetActive(true);
        _rank.sprite = AtlasManager.instance.GetRankSprite(_gameDirector.rank);

        SetPauseMenu(true);

        PauseMenuTitle(true);

        //PauseMenuUpdate();
    }

    void PauseMenuTitle(bool clear)
    {
        _titleText.text = (clear) ? "Result" : "Pause";
    }

    public void PauseMenuRetry()
    {
        _gameDirector.GameInit();

        PauseMenuExit();
    }

    public void PauseMenuQuit()
    {
        _gameDirector.GameQuit();

        PauseMenuExit();
    }

    private void PauseMenuExit()
    {
        PauseMenuInit();

        _rank.sprite = null;

        _btnManager.BtnIntaractableStartAndUndo(true);

        Time.timeScale = 1.0f;
    }
}
