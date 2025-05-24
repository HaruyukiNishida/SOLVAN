using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VanManager : MonoBehaviour
{
    TamaManager[] ketas;
    //   private List<Mondai> mondaiList;

    [SerializeField] GameDirector _gameDirector;
    [SerializeField] TextMeshProUGUI totalTxt;

    [SerializeField] Slider slider;

    //   int currentSum = 0;
    //   int currentCount = 0;
    int subTotal = 0;

    private void Awake()
    {
        ketas = GetComponentsInChildren<TamaManager>();
    }

    public void UpdateTotal()
    {
        UpdateTotalDisp();

        _gameDirector.Calc();
        
    }

    public void UpdateTotalDisp()
    {
        var gettotal = GetTotal();
        var subtotal = subTotal;

        //   totalTxt.text = GetTotal().ToString();
        totalTxt.text = $"getTotal / {gettotal}\n subTotal / {subtotal}";
    }

    /*
    public void GameDir()
    {
        if (currentCount >= 10) return;

        mondaiList = _mondaiManager.GetMondaiList();

        currentSum = GetTotal();

        
        //int sum = 0;
        //for (int i = 0; i <= currentCount; i++)
        //{
        //    sum += mondaiList[i].num;
        //}
        
        //if (currentSum == sum)
        //{
        //    MondaiHit(currentCount);

        //}
        

        for (int i = 0; i < mondaiList.Count; i++)
        {
            Debug.Log($"{i} / {currentSum} /{subTotal + mondaiList[i].num}");

            if (mondaiList[i].active)
            {

                if (currentSum == subTotal + mondaiList[i].num)
                {


                    MondaiHit(i);
                    break;
                }
            }
        }

        
    }

    void MondaiHit(int i)
    {
        //mondaiList[i].GetComponent<TextMeshPro>().enabled = false;
        mondaiList[i].GetComponentInChildren<TextMeshPro>().color = Color.gray;

        mondaiList[i].active = false;

        currentCount++;
        subTotal = currentSum;

        if (currentCount >= 10)
        {
            GameClear();
        }

    }


    void GameClear()
    {
        resultTxt.GetComponent<TMP_Text>().text = $"{GetTotal()}";
        resultTxt.enabled = true;
    }
    */

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
