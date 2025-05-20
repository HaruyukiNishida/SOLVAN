using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MondaiManager : MonoBehaviour
{
    [SerializeField] public Mondai mondaiPrefab;

    List<Mondai> mondaiList = new List<Mondai>();


    private int mondaiCount = 10;
    private float interval = 3.0f;

    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    private Vector3 topLeft;
    private Vector3 topRight;

    public int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        MondaiMake();

        //   Invoke("Syutudai", interval);

        //   Invoke("SyutudaiEnd", interval * mondais.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MondaiMake()
    {

        for (int i = 0; i < mondaiCount; i++)
        {
            MondaiMakeSub(i);


        }

        for (int i = 0; i < mondaiCount; i++)
        {
            MondaiHaiti(i);


        }


    }



    public List<Mondai> GetMondaiList()
    {
        return mondaiList;
    }


    void DrawLine()
    {
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();


        var positions = new Vector3[]
        {
            bottomLeft,
            bottomRight,
            topRight,
            topLeft,
            bottomLeft,
        };

        renderer.positionCount = positions.Length;
        // 線を引く場所を指定する
        renderer.SetPositions(positions);

    }


    void MondaiMakeSub(int i)
    {
        Mondai mondai = Instantiate(mondaiPrefab, transform);
        mondaiList.Add(mondai);

        int randNum = Random.Range(1, 10 * level);
        mondai.GetComponent<Mondai>().num = randNum;
        mondai.GetComponent<Mondai>().index = i;
        mondai.GetComponent<TextMeshPro>().text = randNum.ToString();

        //   MondaiArrange(mondai);
    }

    void MondaiHaiti(int i)
    {
        var dx = topLeft.x;
        var mondai = mondaiList[i];

        float x = dx + 2 * i;
        float y = topLeft.y + 10;

        mondai.transform.position = new Vector3(x, y, 0f);

    }


    void SetPositionsScreenToWorld()
    {
        Camera cam = Camera.main;

        // スクリーン座標の端を取得
        bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        bottomRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, cam.nearClipPlane));
        topLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, cam.nearClipPlane));
        topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.nearClipPlane));

        Debug.Log($"Bottom Left: {bottomLeft}");
        Debug.Log($"Bottom Right: {bottomRight}");
        Debug.Log($"Top Left: {topLeft}");
        Debug.Log($"Top Right: {topRight}");
        /*
        var positions = new Vector3[]
        {
                bottomLeft,
                bottomRight,
                topRight,
                topLeft,
                bottomLeft,
        };

        return positions;
        */
    }

    void SetPositionsScreenWidth()
    {
        bottomLeft = new Vector3(0, 0, 0);
        bottomRight = new Vector3(Screen.width, 0, 0);
        topLeft = new Vector3(Screen.width, Screen.height, 0);
        topRight = new Vector3(0, Screen.height, 0);

        Debug.Log($"Bottom Left: {bottomLeft}");
        Debug.Log($"Bottom Right: {bottomRight}");
        Debug.Log($"Top Left: {topLeft}");
        Debug.Log($"Top Right: {topRight}");

    }

    void MondaiArrange(Mondai mondai)
    {
        float coefficient = 200f;

        int x = (int)Random.Range(-Screen.width / coefficient, Screen.width / coefficient);
        int y = (int)Random.Range(-Screen.height / coefficient, Screen.height / coefficient);

        mondai.transform.position = new Vector3(x, y, 0f);

    }






    public void Syutudai()
    {
        StartCoroutine(SyutudaiSub());


    }

    IEnumerator SyutudaiSub()
    {
        foreach (Mondai mondai in mondaiList)
        {
            yield return new WaitForSeconds(interval);
            //   Destroy(mondai,interval);
        }
    }


    public void SyutudaiEnd()
    {
        CancelInvoke("Syutudai");
        Debug.Log("End");

    }

}
