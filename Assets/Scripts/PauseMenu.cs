using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] TMP_Text _titleText;
    [SerializeField] TMP_Text _answerText;
    [SerializeField] TMP_Text _countText;
    [SerializeField] TMP_Text _hitText;

    private bool _active = false;

    private void Awake()
    {
        PauseMenuInit();
    }

    public void PauseMenuInit()
    {
        _active = false;

        PauseMenuTitle(false);

        this.gameObject.SetActive(false);
    }

    public void Toggle()
    {
        _active = !_active;

        SetPauseMenu(_active);
    }

    void SetPauseMenu(bool active)
    {
        this.gameObject.SetActive(active);

        _btnManager.BtnIntaractable(!active);

        Time.timeScale = (!active) ? 1.0f : 0f;

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
        _active = false;

        Toggle();

        PauseMenuTitle(true);

        PauseMenuUpdate();
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

        _btnManager.BtnIntaractable(true);

        Time.timeScale = 1.0f;
    }


}
