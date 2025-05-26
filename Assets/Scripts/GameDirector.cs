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

    TamaManager[] ketas;
    private List<Mondai> mondaiList;

    int currentSum { get; set; }
    int currentCount { get; set; }
    int subTotal { get; set; }
    int answer { get; set; }

    public bool gameActive = false;

    private void Awake()
    {
        gameActive = false;
    }

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
            //RestartŽž‚Ìˆ—
            _vanManager.VanReset();
            _mondaiManager.MondaiReset();
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
        mondaiList[i].MondaiHit();

        currentCount++;
        subTotal = currentSum;

        if (currentCount >= 10)
        {
            GameClear();
        }

    }


    void GameClear()
    {
        _resultTxt.GetComponent<TMP_Text>().text = $"{_vanManager.GetTotal()}";
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
}
