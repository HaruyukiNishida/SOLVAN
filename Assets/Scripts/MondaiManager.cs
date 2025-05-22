using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class MondaiManager : MonoBehaviour
{
    [SerializeField] public Mondai mondaiPrefab;


    List<Mondai> mondaiList = new List<Mondai>();


    private int mondaiCount = 10;
    private float interval = 1.0f;

    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    private Vector3 topLeft;
    private Vector3 topRight;

    private float posZ = -2f;

    private Vector3 canvas;

    public int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //   SetPositionsScreenToWorld();
        //transform.position = new Vector3(Screen.width , Screen.height , 0f);

        //transform.position = GameObject.Find("VanManager").transform.position;


        MondaiMake();

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
            //    MondaiArrangeLine(mondaiList[i]);

            //   MondaiArrangeRandom(mondaiList[i]);
            MondaiArrangeRight(mondaiList[i]);



        }

        MondaiActive();
    }



    public List<Mondai> GetMondaiList()
    {
        return mondaiList;
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



        mondai.transform.position = new Vector3(x, y, posZ);

    }
    void MondaiArrangeLine(Mondai mondai)
    {
        var dx = 0;

        float x = dx + 1f * mondai.index;
        float y = 4f;

        mondai.transform.position = new Vector3(x, y, posZ);

    }

    void MondaiArrangeRight(Mondai mondai)
    {
        Camera cam = Camera.main;
        Vector3 viewportPosition = new Vector3(1f, 1f, -cam.transform.position.z);
        Vector3 worldPosition = cam.ViewportToWorldPoint(viewportPosition);
        Vector3 screenPosition = cam.ViewportToScreenPoint(viewportPosition);

        float dx = worldPosition.x;
        float dy = worldPosition.y;

        float x = dx;
        float y = Random.Range(0, dy);

        Debug.Log(cam.transform.position.z);

        mondai.transform.position = new Vector3(x, y, posZ);


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
            yield return new WaitForSeconds(interval);
        }
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