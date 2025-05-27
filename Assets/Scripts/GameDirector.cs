using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _totalTxt;
    [SerializeField] TextMeshProUGUI _resultTxt;
    [SerializeField] private VanManager _vanManager;
    [SerializeField] private MondaiManager _mondaiManager;
    [SerializeField] private BtnManager _btnManager;
    [SerializeField] private Menu _menu;

    TamaManager[] ketas;
    private List<Mondai> mondaiList;

    int currentSum;
    int currentCount;
    int countMax;
    int subTotal;
    int answer;

    public bool gameActive = false;

    private void Awake()
    {
        gameActive = false;
    }

    private void Update()
    {
        if (gameActive && currentCount >= countMax)
        {
            Time.timeScale = 0;
            GameClear();
        }
    }



    public void GameInit()
    {
        currentSum = 0;
        currentCount = 0;
        countMax = 10;
        subTotal = 0;
        answer = 0;

        if (!gameActive)
        {
            gameActive = true;

            _vanManager.VanReset();
            _mondaiManager.MondaiInit();
        }
        else
        {
            //RestartŽž‚Ìˆ—
            _vanManager.VanReset();
            _mondaiManager.MondaiRestart();
        }

        _btnManager.BtnDisp(gameActive);
    }

    public void GameQuit()
    {
        _vanManager.VanReset();
        _mondaiManager.MondaiDestroy();
        gameActive = false;

        _btnManager.BtnDisp(false);
    }

    public void Calc()
    {
        if (!gameActive) return;

        if (currentCount >= 10) return;

        mondaiList = _mondaiManager.GetMondaiList();

        currentSum = _vanManager.GetTotal();


        /*
        int sum = 0;
        for (int i = 0; i <= currentCount; i++)
        {
            sum += mondaiList[i].num;
        }
        
        if (currentSum == sum)
        {
            MondaiHit(currentCount);

        }
        */

        for (int i = 0; i < mondaiList.Count; i++)
        {
            //    Debug.Log($"{i} / {currentSum} /{subTotal + mondaiList[i].num}");

            if (mondaiList[i].status == MondaiStatus.Active)
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
        mondaiList[i].MondaiHit();

        currentCount++;
        subTotal = currentSum;



    }


    void GameClear()
    {
        int answer=_mondaiManager.GetAnswer();


        _resultTxt.GetComponent<TMP_Text>().text = $"{_vanManager.GetTotal()} / {answer}";
        _resultTxt.enabled = true;
    }

    public void TotalDisp()
    {
        _totalTxt.text = $"currentSum / {currentSum}\n subTotal / {subTotal}";

    }

    public void UndoBtn()
    {
        _vanManager.VanUndo(subTotal);
    }

    public void CountUp()
    {
        currentCount++;
    }
}
