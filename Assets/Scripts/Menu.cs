using UnityEngine;

public class Menu : MonoBehaviour
{
    //ゲーム時　Undoボタン
    //非

    //ゲーム時にはポーズ機能＆解除、終了ボタンを表示
    //非ゲーム時では以下の設定を変更できる

    //問題数
    //スピード
    //読み上げ音声ONOFF
    //珠の種類
    //盤の種類
    //盤の傾き


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Toggle()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);


    }



}
