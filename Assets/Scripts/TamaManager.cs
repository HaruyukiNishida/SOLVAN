using TMPro;
using UnityEngine;

public class TamaManager : MonoBehaviour
{
    public static TamaManager instance;

    public TextMeshProUGUI txt;

    public Tama1[] tamas;

    public int subTotal = 0;
    public int keta = 1;

    private void Awake()
    {
        // インスタンスが未設定の場合の処理
        if (instance == null)
        {
            // このクラスのインスタンスを設定
            instance = this;
            // シーンが切り替わってもオブジェクトが破棄されないように設定
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // すでにインスタンスが存在する場合、このオブジェクトを破棄
            Destroy(gameObject);
        }

        tamas = new Tama1[5];

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     //   tamas = new Tama1[5];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTamas(Tama1 tama, int index)
    {
        tamas[index] = tama;

    }

    public void DispSubTotal()
    {

        txt.text = DispSubTotalSub().ToString();
    }

    public int DispSubTotalSub()
    {
        subTotal = 0;
        for (int i = 0; i <= 4; i++)
        {
            subTotal += (tamas[i].isOn) ? ((i == 4) ? 5 : 1) : 0;
        }

        return subTotal * keta;

    }


    public void MoveTamas(int index, TamaStatus movestatus)
    {
        if (movestatus == TamaStatus.Up)
        {
            for (int i = index; i < 4; i++)
            {
                tamas[i].SetTamaMove(movestatus);
            }
        }
        else
        {
            for (int i = index; i >= 0; i--)
            {
                tamas[i].SetTamaMove(movestatus);
            }

        }
    }






}
