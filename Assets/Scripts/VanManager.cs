using UnityEngine;
using UnityEngine.UI;

public class VanManager : MonoBehaviour
{
    TamaManager[] ketas;

    [SerializeField] GameDirector _gameDirector;

    [SerializeField] Slider slider;


    private void Awake()
    {
        ketas = GetComponentsInChildren<TamaManager>();
    }

    public void UpdateTotal()
    {
        _gameDirector.Calc();

    }

    public void UpdateTotalDisp()
    {
        _gameDirector.TotalDisp();
    }


    public void VanRotate()
    {
        if (GetTotal() != 0) VanReset();


        Vector3 eulerAngles = transform.eulerAngles; // ローカル変数に格納
        eulerAngles.x = (float)slider.value; // ローカル変数に格納した値を上書き
        transform.eulerAngles = eulerAngles; // ローカル変数を代入

        //珠の始点終点を再設定
        for (int i = 0; i < ketas.Length; i++)
        {
            ketas[i].transform.eulerAngles = eulerAngles;
            ketas[i].SetTamasInit();
        }


    }

    public void VanReset()
    {
        VanSet(0);

        UpdateTotalDisp();
    }

    public void VanUndo(int subTotal)
    {
        VanSet(subTotal);

        UpdateTotalDisp();
    }

    public void VanSet(int value)
    {
        for (int i = 0; i < ketas.Length; i++)
        {
            ketas[i].SetPositionTama(value % 10);
            value /= 10;
        }
    }


    public int GetTotal()
    {
        var total = 0;
        foreach (TamaManager keta in ketas)
        {
            total += keta.GetSubTotal();
        }

        return total;
    }

}
