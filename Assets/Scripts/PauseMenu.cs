using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] GameObject _pauseMenuPanel;
    [SerializeField] TMP_Text _titleText;
    [SerializeField] TMP_Text _answerText;
    [SerializeField] TMP_Text _countText;
    [SerializeField] TMP_Text _hitText;

    private bool _active = false;

    private void Start()
    {
        PauseMenuInit();
    }

    public void PauseMenuInit()
    {
        _active = false;

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
        }
    }


    private void PauseMenuUpdate()
    {
        int count = _gameDirector.currentCount;
        int hit = _gameDirector.hitCount;
        int max = _gameDirector.countMax;
        int answer = _gameDirector.answer;

        _countText.text = $"{count} / {max}";
        _hitText.text = $"{hit}";
        _answerText.text = (answer == 0) ? "?????" : answer.ToString();

    }

    public void GameClear(int answer)
    {
        _btnManager.BtnIntaractablePause(false);

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

        _btnManager.BtnIntaractableStartAndUndo(true);

        Time.timeScale = 1.0f;
    }
}
