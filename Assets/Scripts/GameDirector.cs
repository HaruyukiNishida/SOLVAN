using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _totalTxt;
    [SerializeField] TextMeshProUGUI _resultTxt;
    [SerializeField] private VanManager _vanManager;
    [SerializeField] private MondaiManager _mondaiManager;
    [SerializeField] private BtnManager _btnManager;
    [SerializeField] private Menu _menu;
    [SerializeField] private PauseMenu _pauseMenu;

    TamaManager[] ketas;
    private List<Mondai> mondaiList;

    public int hitCount;
    public int countMax;
    public int answer;

    int currentTotal;
    public int currentCount;

    int subTotal;


    public bool gameActive = false;

    private void Awake()
    {
        //android�p����ʌŒ�
        // �c
        Screen.autorotateToPortrait = false;
        // ��
        //   Screen.autorotateToLandscapeLeft = true;
        // �E
        //   Screen.autorotateToLandscapeRight = true;
        // �㉺���]
        Screen.autorotateToPortraitUpsideDown = true;

        gameActive = false;
    }

    private void Update()
    {
        if (gameActive && currentCount >= _menu.mondaiCount)
        {
            Time.timeScale = 0;
            GameClear();
        }
    }

    public void GameInit()
    {
        hitCount = 0;                   //��蓖�Ă���
        currentTotal = 0;                 //
        currentCount = 0;               //������ځH
        countMax = _menu.mondaiCount;   //��萔
        subTotal = 0;   //���݂̏��v
        answer = 0;

        if (!gameActive)
        {
            gameActive = true;

            _vanManager.VanReset();
            _mondaiManager.MondaiInit();

            _pauseMenu.PauseMenuInit();
        }
        else
        {
            //Restart���̏���
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

        currentTotal = _vanManager.GetTotal();


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
            if (mondaiList[i].status == MondaiStatus.Active)
            {
                if (currentTotal == subTotal + mondaiList[i].num)
                {
                    MondaiHit(i);
                    break;
                }
            }
        }


    }

    void MondaiHit(int i)
    {
        mondaiList[i].MondaiGone();
        _mondaiManager.hitFlag = true;

        hitCount++;
        subTotal = currentTotal;
    }


    void GameClear()
    {
        answer = _mondaiManager.GetAnswer();

        _pauseMenu.GameClear(answer);

        _resultTxt.GetComponent<TMP_Text>().text = $"{_vanManager.GetTotal()} / {answer}";
        _resultTxt.enabled = true;
    }

    public void TotalDisp()
    {

        //   _totalTxt.text = $"currentSum / {currentSum}\n subTotal / {subTotal}";
        //   _resultTxt.text = currentCount.ToString() ;
        // HIT��/�o����/����
        _totalTxt.text = $"Hit : {hitCount}  / Count : {currentCount} / Max : {_menu.mondaiCount} ";

    }

    public void UndoBtn()
    {
        _vanManager.VanUndo(subTotal);
    }

    public void CountUp()
    {
        currentCount++;

        TotalDisp();
    }
}
