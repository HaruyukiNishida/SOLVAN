using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class VanManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalTxt;
    TamaManager[] ketas;
    public int subTotal;
    private List<Mondai> mondaiList;

    [SerializeField] MondaiManager _mondaiManager;
    [SerializeField] TextMeshProUGUI resultTxt;

    int currentCount = 0;

    private void Awake()
    {
        ketas = GetComponentsInChildren<TamaManager>();
        TxtClear();
    }




    public void UpdateTotal()
    {
        totalTxt.text = GetTotal().ToString();

        GameDir();
    }

    public void GameDir()
    {
        if (currentCount >= 10) return;

        mondaiList = _mondaiManager.GetMondaiList();

        int currentTotal = GetTotal();

        int sum = 0;
        for (int i = 0; i <= currentCount; i++)
        {
            sum += mondaiList[i].num;
        }

        if (currentTotal == sum)
        {
            mondaiList[currentCount].GetComponent<TextMeshPro>().enabled=false;

            currentCount++;
            resultTxt.text = $"{currentCount} Clear";
            Invoke("TxtClear", 3f);


        }


    }

    void TxtClear()
    {
        resultTxt.text = $"---";

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
