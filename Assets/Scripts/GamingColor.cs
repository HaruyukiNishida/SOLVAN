using UnityEngine;

public class GamingColor : MonoBehaviour
{
    private float time = 0;
    private Color blendedColor;
    private Color color1 = Color.cyan;
    private Color color2 = Color.magenta;

    public static GamingColor instance;

    // ゲームオブジェクトが起動時に呼ばれるメソッド（MonoBehaviour）
    private void Awake()
    {
        // インスタンスが未設定の場合の処理
        if (instance == null)
        {
            // このクラスのインスタンスを設定
            instance = this;
            // シーンが切り替わってもオブジェクトが破棄されないように設定
         //   DontDestroyOnLoad(gameObject);
        }
        else
        {
            // すでにインスタンスが存在する場合、このオブジェクトを破棄
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blendedColor = Color.white;
    }

    void Update()
    {
        time += Time.deltaTime * 5; // 点滅速度を調整
        float alpha = (Mathf.Sin(time) + 1) / 2; // sin値を0～1の範囲に変換

        if (time > 18f) time = 0;

        blendedColor = Color.Lerp(color1, color2, alpha);
    }

    public Color GetGamingColor()
    {
        return blendedColor;
    }

}
