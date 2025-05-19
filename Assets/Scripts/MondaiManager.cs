using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MondaiManager : MonoBehaviour
{
    [SerializeField] public Mondai mondaiPrefab;

    List<Mondai> mondais = new List<Mondai>();

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

    public void MondaiMake()
    {
        for (int i = 0; i < 10; i++)
        {
            Mondai mondai = Instantiate(mondaiPrefab, transform);
            int randNum = Random.Range(0, 1000);
            mondai.GetComponent<Mondai>().num = randNum;
            mondai.GetComponent<Mondai>().index = i;


            mondais.Add(mondai);
            var x = Random.Range(-3f, 3f) * 100f;
            var y = Random.Range(-2f, 2f) * 100f;

            mondai.transform.localPosition = new Vector3(x, y, 0);
            mondai.GetComponentInChildren<TextMeshProUGUI>().text = randNum.ToString();




        }
    }

    public void Syutudai()
    {
        StartCoroutine(SyutudaiSub());


    }

    IEnumerator SyutudaiSub()
    {
        foreach (Mondai mondai in mondais)
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
