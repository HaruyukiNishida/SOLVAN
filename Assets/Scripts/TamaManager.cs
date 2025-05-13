using UnityEngine;

public class TamaManager : MonoBehaviour
{
    public static TamaManager instance;

    public Tama1[] tamas;

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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTamas(Tama1 tama, int index)
    {
        tamas[index] = tama;

    }

    public void MoveTamas(int index, int movestatus)
    {
        if (movestatus == 1)
        {
            for (int i = index; i <= 3; i++)
            {

                tamas[i].SetTamaMove(movestatus);
            }
        }
        else
        {
            for (int i = index; i >= 0; i--)
            {
                //  if (!tamas[i].isOn)
                {
                    tamas[i].SetTamaMove(movestatus);
                }
            }

        }
    }






}
