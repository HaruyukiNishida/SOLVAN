using System.Threading;
using TMPro;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    [SerializeField]TMP_Text _startBtnTxt;

    private Timer Timer;
    private float time = 0;
    private Color color1 = Color.cyan;
    private Color color2 = Color.magenta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * 5; // 点滅速度を調整
        float alpha = (Mathf.Sin(time) + 1) / 2; // sin値を0～1の範囲に変換

        // 色の変化を追加
        Color blendedColor = Color.Lerp(color1, color2, alpha);
        _startBtnTxt.color = new Color(blendedColor.r, blendedColor.g, blendedColor.b, alpha);

     //   _startBtnTxt.color = new Color(_startBtnTxt.color.r, _startBtnTxt.color.g, _startBtnTxt.color.b, alpha); // アルファ値を変更

    }



}
