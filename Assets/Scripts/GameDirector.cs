using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _countTxt;
    [SerializeField] TextMeshProUGUI _hitTxt;
    [SerializeField] VanManager _vanManager;
    [SerializeField] MondaiManager _mondaiManager;
    [SerializeField] BtnManager _btnManager;
    [SerializeField] Menu _menu;
    [SerializeField] PauseMenu _pauseMenu;
    [SerializeField] Title _title;

    TamaManager[] ketas;
    List<Mondai> mondaiList;

    public int hitCount;
    public int countMax;
    public int answer;
    public int currentCount;

    int currentTotal;
    int subTotal;
    int currentAnswer;

    public bool gameActive = false;
    public bool isClear = false;

    private void Awake()
    {
        //android—p‰¡‰æ–ÊŒÅ’è
        // c
        Screen.autorotateToPortrait = false;
        // ¶
        //   Screen.autorotateToLandscapeLeft = true;
        // ‰E
        //   Screen.autorotateToLandscapeRight = true;
        // ã‰º”½“]
        Screen.autorotateToPortraitUpsideDown = true;

        gameActive = false;
        isClear = false;

    }

    private void Update()
    {
        if (isClear) return;

        if (gameActive && currentCount >= _menu.mondaiCount)
        {
            isClear = true; ;

            Invoke("GameClear", 1f);
            //    GameClear();
        }
    }

    public void GameInit()
    {
        hitCount = 0;                   //–â‘è“–‚Ä‚½”
        currentTotal = 0;                 //
        currentCount = 0;               //¡‰½–â–ÚH
        countMax = _menu.mondaiCount;   //–â‘è”
        subTotal = 0;   //Œ»Ý‚Ì¬Œv
        answer = 0;
        currentAnswer = 0;

        isClear = false;

        if (!gameActive)
        {
            gameActive = true;

            _vanManager.VanReset();
            _mondaiManager.MondaiInit();

            _pauseMenu.PauseMenuInit();

            _title.LogoDisp(false);
        }
        else
        {
            //RetryŽž‚Ìˆ—
            _vanManager.VanReset();
            _mondaiManager.MondaiRestart();
        }

        TotalDisp();
        _btnManager.BtnDisp(gameActive);
        _btnManager.BtnIntaractablePause(true);

    }

    public void GameQuit()
    {
        gameActive = false;

        _vanManager.VanReset();
        _mondaiManager.MondaiDestroy();

        _btnManager.BtnDisp(false);
        _title.LogoDisp(true);

        TotalDisp();
    }

    public void Calc()
    {
        if (!gameActive) return;

        if (currentCount >= 10) return;

        mondaiList = _mondaiManager.GetMondaiList();

        currentTotal = _vanManager.GetTotal();

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

        GameObject.FindFirstObjectByType<GameClear>().ClearSub(hitCount == countMax);
    }


    public void TotalDisp()
    {
        _countTxt.text = (gameActive) ? $"{currentCount} / {_menu.mondaiCount}" : string.Empty;

        _hitTxt.text = (gameActive) ? $"{hitCount} Hit" : string.Empty;

    }

    public void UndoBtn()
    {
        _vanManager.VanUndo(subTotal);
    }

    public void CountUp(int num)
    {
        currentCount++;
        currentAnswer += num;

        TotalDisp();
    }
}
