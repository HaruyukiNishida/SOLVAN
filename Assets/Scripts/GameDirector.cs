using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI totalTxt;
    [SerializeField] TextMeshProUGUI resultTxt;
    [SerializeField] private VanManager _vanManager;
    [SerializeField] private MondaiManager _mondaiManager;

    TamaManager[] ketas;
    private List<Mondai> mondaiList;

    int currentSum = 0;
    int currentCount = 0;
    int subTotal = 0;
    int answer = 0;

    public bool gameActive = false;

    void Start()
    {
    }

    void Update()
    {

    }

    public void GameInit()
    {
        currentSum = 0;
        currentCount = 0;
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
            _vanManager.VanReset();
            _mondaiManager.MondaiReset();
        }
    }

    public void GameQuit()
    {
        _vanManager.Quit();
        gameActive = false;

        

    }

    public void Calc()
    {
        if (!gameActive) return;

        Debug.Log("Calc");

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
        

        currentCount++;
        subTotal = currentSum;

        if (currentCount >= 10)
        {
            GameClear();
        }

    }


    void GameClear()
    {
        resultTxt.GetComponent<TMP_Text>().text = $"{_vanManager.GetTotal()}";
        resultTxt.enabled = true;
    }


}
