using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MondaiManager : MonoBehaviour
{
    [SerializeField] Mondai _mondaiPrefab;
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] Menu _menu;

    List<Mondai> mondaiList = new List<Mondai>();

    private Coroutine coroutine;

    private float mondaiPosZ = -2f;

    private float interval;
    private float duration;
    private int level;
    private int mondaiCount;
    private int mode;
    private int answer;

    public bool hitFlag;

    public List<Mondai> GetMondaiList()
    {
        return mondaiList;
    }

    public int GetAnswer()
    {
        return answer;
    }

    void SetParamFromMenu()
    {
        interval = _menu.interval;
        duration = _menu.duration;
        level = _menu.level;
        mondaiCount = _menu.mondaiCount;
        mode = _menu.mode;

        answer = 0;
        hitFlag = false;
    }


    public void MondaiInit()
    {
        SetParamFromMenu();
        mondaiList.Clear();

        for (int i = 0; i < mondaiCount; i++)
        {
            MondaiMake(i);

            //    MondaiArrangeLine(mondaiList[i]);

            if (mode == 0)
            {
                MondaiArrangeRandom(mondaiList[i]);
            }
            else
            {
                MondaiArrangeRight(mondaiList[i]);
            }

            answer += mondaiList[i].num;
            mondaiList[i].MondaiInit();
        }

        MondaiActive();
    }

    void MondaiMake(int i)
    {
        Mondai mondai = Instantiate(_mondaiPrefab, transform);
        mondai.DependencyInjection(_gameDirector);
        mondai.DependencyInjection(_menu);

        mondai.GetComponent<Mondai>().num = MondaiNumMake();

        mondaiList.Add(mondai);
    }

    private int MondaiNumMake()
    {
        int randNum = Random.Range(1, (int)Mathf.Pow(10, level));

        return randNum;
    }



    void MondaiArrangeRandom(Mondai mondai)
    {
        //  float coefficientX = 400f;
        //  float coefficientY = 400f;

        //  int x = (int)Random.Range(-Screen.width / coefficientX, Screen.width / coefficientX);
        //  int y = (int)Random.Range(-Screen.height / coefficientY, Screen.height / coefficientY);

        float coefficientX = 0.60f;
        float coefficientY = 0.60f;

        float y1 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Top);
        float y2 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Bottom);
        float x1 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Left);
        float x2 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Right);

        float x = Random.Range(x1 * coefficientX, x2 * coefficientX);
        float y = Random.Range(y1 * coefficientY, y2 * coefficientY);


        mondai.transform.position = new Vector3(x, y, mondaiPosZ);
        mondai.transform.localScale = Vector3.one;
     //   mondai.GetComponentInChildren<TextMeshPro>().color = new Color(0, 0, 0, 0);

    }
    void MondaiArrangeLine(Mondai mondai)
    {
        var dx = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Left);
        var dy = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Top);

        float x = dx + 1f * mondaiList.IndexOf(mondai);
        float y = 4f;

        mondai.transform.position = new Vector3(x, y, mondaiPosZ);

    }

    void MondaiArrangeRight(Mondai mondai)
    {
        //   float coefficientX = 0.75f;
        float coefficientY = 0.70f;

        float y1 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Top);
        float y2 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Bottom);

        float x = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Right);
        float y = Random.Range(y1 * coefficientY, y2 * coefficientY);

        mondai.transform.position = new Vector3(x, y, mondaiPosZ);
    }



    void MondaiActive()
    {
        coroutine = StartCoroutine(MondaiActiveSub());
    }

    IEnumerator MondaiActiveSub()
    {
        //   var wait = new WaitForSeconds(interval);

        for (int i = 0; i < mondaiCount; i++)
        {
            if (mode == 0)
            {
                mondaiList[i].Scaling();
            }
            else
            {
                mondaiList[i].MoveRightToLeft();
            }

            float elapsedTime = 0f;

            while (!hitFlag && elapsedTime < interval)
            {
                elapsedTime += Time.deltaTime;
                yield return null; // –ˆƒtƒŒ[ƒ€‘Ò‹@
            }

            hitFlag = false;
            //  yield return new WaitForSeconds(wait);
        }
    }

    public void MondaiRestart()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        for (int i = 0; i < mondaiCount; i++)
        {
            mondaiList[i].MondaiInit();
            mondaiList[i].MondaiRestart();
        }

        MondaiActive();

    }


    public void MondaiDestroy()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);

            for (int i = 0; i < mondaiCount; i++)
            {
                if (mondaiList[i] != null)
                    mondaiList[i].Destroy();
            }
        }

    }

}
