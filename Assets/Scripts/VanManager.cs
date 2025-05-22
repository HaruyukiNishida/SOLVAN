using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VanManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalTxt;
    TamaManager[] ketas;
    private List<Mondai> mondaiList;

    [SerializeField] MondaiManager _mondaiManager;
    [SerializeField] TextMeshProUGUI resultTxt;

    [SerializeField] Slider slider;

    int currentCount = 0;
    int subTotal = 0;

    private void Awake()
    {
        ketas = GetComponentsInChildren<TamaManager>();
        resultTxt.enabled=false;
    }

    public void UpdateTotal()
    {
        UpdateTotalDisp();

        GameDir();
    }

    public void UpdateTotalDisp()
    {
        totalTxt.text = GetTotal().ToString();
    }

    public void GameDir()
    {
        if (currentCount >= 10) return;

        mondaiList = _mondaiManager.GetMondaiList();

        int currentSum = GetTotal();

        int sum = 0;
        for (int i = 0; i <= currentCount; i++)
        {
            sum += mondaiList[i].num;
        }

        if (currentSum == sum)
        {
            //mondaiList[currentCount].GetComponent<TextMeshPro>().enabled = false;
            mondaiList[currentCount].GetComponentInChildren<TextMeshPro>().color = Color.gray;

            currentCount++;
            subTotal = currentSum;

            if (currentCount >= 10)
            {
                GameClear();
            }
        }
    }

    void GameClear()
    {
        resultTxt.enabled = true;
    }

    public void VanRotate()
    {
        Debug.Log(slider.value);

        Vector3 eulerAngles = transform.eulerAngles; // ローカル変数に格納
        eulerAngles.x = (float)slider.value; // ローカル変数に格納した値を上書き
        transform.eulerAngles = eulerAngles; // ローカル変数を代入

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

    public void VanUndo()
    {
        Debug.Log(subTotal);

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
        var subTotal = 0;
        foreach (TamaManager keta in ketas)
        {
            subTotal += keta.GetSubTotal();
        }

        return subTotal;
    }

}
