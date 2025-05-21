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

    private Vector3 canvas;

    public int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     //   SetPositionsScreenToWorld();
     //   transform.position = new Vector3(topLeft.x,topLeft.y,topLeft.z);
        transform.position = GameObject.Find("VanManager").transform.position;


        MondaiMake();

        //   Invoke("Syutudai", interval);

        //   Invoke("SyutudaiEnd", interval * mondais.Count);
    }

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
            MondaiArrangeLine(mondaiList[i]);

         //   MondaiArrangeRandom(mondaiList[i]);

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

        MondaiArrangeRandom(mondai);
    }

    void MondaiArrangeRandom(Mondai mondai)
    {


        float coefficient = 200f;

        int x = (int)Random.Range(-Screen.width / coefficient, Screen.width / coefficient);
        int y = (int)Random.Range(-Screen.height / coefficient, Screen.height / coefficient);

        //int x = (int)Random.Range(topLeft.x, topRight.x );
        //int y = (int)Random.Range(topLeft.y , bottomLeft.y);

        mondai.transform.position = new Vector3(x, y, 0f);

    }
    void MondaiArrangeLine(Mondai mondai)
    {
        var dx = topLeft.x;

        float x = dx + 1 * mondai.index;
        float y = 9.5f;//topLeft.y;

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

/*
public class Zahyou
{
    public Vector3 bottomLeft;
    public Vector3 bottomRight;
    public Vector3 topLeft;
    public Vector3 topRight; 
}
*/