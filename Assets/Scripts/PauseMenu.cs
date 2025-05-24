using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]GameDirector _gameDirector;

    //ポーズメニュー
    //
    //同じ問題を最初から
    //ゲームを抜ける



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);

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

        Time.timeScale = 1.0f;

    }
}
