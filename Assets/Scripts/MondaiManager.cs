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

    }

    void MondaiMakeSub(int i)
    {
        Mondai mondai = Instantiate(mondaiPrefab, transform);
        mondaiList.Add(mondai);

        int randNum = Random.Range(0, 1000);
        mondai.GetComponent<Mondai>().num = randNum;
        mondai.GetComponent<Mondai>().index = i;

        int x = (int)Random.Range(-3f, 3f);
        int y = (int)Random.Range(-2f, 2f);

        mondai.transform.localPosition = new Vector3(x, y, -5.0f);
        mondai.GetComponent<TextMeshPro>().text = randNum.ToString();
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
