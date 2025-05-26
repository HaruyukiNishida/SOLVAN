using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MondaiManager : MonoBehaviour
{
    [SerializeField] Mondai _mondaiPrefab;
    [SerializeField] Menu _menu;

    List<Mondai> mondaiList = new List<Mondai>();

    private Coroutine coroutine;

    private int mondaiCount = 10;
    private float mondaiPosZ = -2f;

    private float interval;
    private int level;
    private float duration;
    private int mode;

    void Start()
    {
       
    }

    void Update()
    {
    }

    public List<Mondai> GetMondaiList()
    {
        return mondaiList;
    }

    void SetParamFromMenu()
    {
        interval = _menu.interval;
        level = _menu.level;
        duration = _menu.duration;
        mode = _menu.mode;
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
        }

        MondaiActive();
    }

    void MondaiMake(int i)
    {
        Mondai mondai = Instantiate(_mondaiPrefab, transform);
        mondaiList.Add(mondai);

        int randNum = Random.Range(1, (int)Mathf.Pow(10, level));
        mondai.GetComponent<Mondai>().index = i;
        mondai.GetComponent<Mondai>().num = randNum;
        mondai.GetComponentInChildren<TMP_Text>().text = randNum.ToString();
        mondai.duration = this.duration;
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

    }
    void MondaiArrangeLine(Mondai mondai)
    {
        var dx = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Left);
        var dy = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Top);

        float x = dx + 1f * mondai.index;
        float y = 4f;

        mondai.transform.position = new Vector3(x, y, mondaiPosZ);

    }

    void MondaiArrangeRight(Mondai mondai)
    {
        //   float coefficientX = 0.75f;
        float coefficientY = 0.75f;

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
        var wait = new WaitForSeconds(interval);

        for (int i = 0; i < mondaiCount; i++)
        {
            mondaiList[i].active = true;

            if (mode == 0)
            {
                mondaiList[i].Scaling();
            }
            else
            {
                mondaiList[i].MoveRightToLeft();
            }

            yield return wait;
        }
    }

    public void MondaiReset()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);

            for (int i = 0; i < mondaiCount; i++)
            {
                mondaiList[i].MondaiRestart();
            }

            MondaiActive();
        }

    }


    public void MondaiDestroy()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);

            for (int i = 0; i < mondaiCount; i++)
            {
                mondaiList[i].Destroy();
            }
        }

    }











    void DrawLine(Vector3[] positions)
    {
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();


        renderer.positionCount = positions.Length;
        // ê¸Çà¯Ç≠èÍèäÇéwíËÇ∑ÇÈ
        renderer.SetPositions(positions);

    }
}
