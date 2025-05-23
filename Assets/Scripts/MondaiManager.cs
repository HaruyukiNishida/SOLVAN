using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MondaiManager : MonoBehaviour
{
    [SerializeField] public Mondai mondaiPrefab;

    List<Mondai> mondaiList = new List<Mondai>();

    private int mondaiCount = 10;
    private float mondaiPosZ = -2f;

    public float interval = 1.0f;
    public int level = 1;
    public float duration;

    void Start()
    {
        MondaiMake();
    }

    void Update()
    {
    }

    public List<Mondai> GetMondaiList()
    {
        return mondaiList;
    }

    private void MondaiMake()
    {

        for (int i = 0; i < mondaiCount; i++)
        {
            MondaiMakeSub(i);

            //    MondaiArrangeLine(mondaiList[i]);

            //   MondaiArrangeRandom(mondaiList[i]);
            MondaiArrangeRight(mondaiList[i]);
        }

        MondaiActive();
    }

    void MondaiMakeSub(int i)
    {
        Mondai mondai = Instantiate(mondaiPrefab, transform);
        mondaiList.Add(mondai);

        int randNum = Random.Range(1, 10 * level);
        mondai.GetComponent<Mondai>().index = i;
        mondai.GetComponent<Mondai>().num = randNum;
        mondai.GetComponentInChildren<TMP_Text>().text = randNum.ToString();

    }

    void MondaiArrangeRandom(Mondai mondai)
    {
        float coefficientX = 400f;
        float coefficientY = 400f;

        int x = (int)Random.Range(-Screen.width / coefficientX, Screen.width / coefficientX);
        int y = (int)Random.Range(-Screen.height / coefficientY, Screen.height / coefficientY);



        mondai.transform.position = new Vector3(x, y, mondaiPosZ);

    }
    void MondaiArrangeLine(Mondai mondai)
    {
        var dx = 0;

        float x = dx + 1f * mondai.index;
        float y = 4f;

        mondai.transform.position = new Vector3(x, y, mondaiPosZ);

    }

    void MondaiArrangeRight(Mondai mondai)
    {

        float y1 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Top);
        float y2 = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Bottom);

        float x = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Right);
        float y = Random.Range(y1 * 0.75f, y2 * 0.75f);

        mondai.transform.position = new Vector3(x, y, mondaiPosZ);
    }

    void MondaiActive()
    {

        StartCoroutine(MondaiActiveSub());
    }

    IEnumerator MondaiActiveSub()
    {
        foreach (Mondai mondai in mondaiList)
        {
            mondai.active = true;
            mondai.duration = 5.0f;
            mondai.MoveRightToLeft();
            yield return new WaitForSeconds(interval);
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
