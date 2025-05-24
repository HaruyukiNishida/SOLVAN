using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]GameDirector _gameDirector;

    public void Toggle()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);

        _gameDirector.BtnIntaractable(!this.gameObject.activeSelf);

        Time.timeScale = (!this.gameObject.activeSelf) ? 1.0f : 0f;
    }

    public void PauseMenuRestart()
    {
        PauseMenuExit();

        _gameDirector.GameInit();
    }

    public void PauseMenuQuit()
    {
        PauseMenuExit();

        _gameDirector.GameQuit();
    }

    private void PauseMenuExit()
    {
        this.gameObject.SetActive(false);

        _gameDirector.BtnIntaractable(true);

        Time.timeScale = 1.0f;
    }
}
