using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] BtnManager _btnManager;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }


    public void Toggle()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);

        _btnManager.BtnIntaractable(!this.gameObject.activeSelf);

        Time.timeScale = (!this.gameObject.activeSelf) ? 1.0f : 0f;
    }

    public void PauseMenuRestart()
    {
        _gameDirector.GameInit();

        PauseMenuExit();
    }

    public void PauseMenuQuit()
    {
        _gameDirector.GameQuit();

        PauseMenuExit();
     //   Time.timeScale = 1.0f;

     //   SceneManager.LoadScene("MainScene");
    }

    private void PauseMenuExit()
    {
        _btnManager.BtnIntaractable(true);

        Time.timeScale = 1.0f;
        
        this.gameObject.SetActive(false);
    }
}
