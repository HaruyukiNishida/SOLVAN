using System.Collections;
using TMPro;
using UnityEngine;

public class Mondai : MonoBehaviour
{
    public int num;
    public int index;
    public bool active;
    public int mode;
    public float duration;

    private void Start()
    {
        GetComponentInChildren<TextMeshPro>().color = Color.white;
    }

    void Update()
    {


    }

    public void MoveRightToLeft()
    {
        mode = 1;
        active = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Left), startPos.y, startPos.z);


        StartCoroutine(MoveRightToLeftSub(startPos, endPos));
    }

    public IEnumerator MoveRightToLeftSub(Vector3 startPos, Vector3 endPos)
    {
        float elapsed = 0f;

        while (elapsed < duration && active)
        {
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(elapsed / duration));

         //   transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0f, 1080f, Mathf.Clamp01(elapsed / duration)));

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos; // 最終位置を確定
    }

    public void Scaling()
    {
        mode = 0;

        Vector3 startScale = transform.localScale;
        Vector3 endScale = new Vector3(2f,2f,1f);

     //   GetComponentInChildren<TextMeshPro>().color = Color.white;

        //   GetComponentInChildren<TextMeshPro>().gameObject.SetActive();
        StartCoroutine(ScalingSub(startScale, endScale));

    }

    public IEnumerator ScalingSub(Vector3 startScale, Vector3 endScale)
    {
        float elapsed = 0f;

       


        while (elapsed < duration && active)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, Mathf.Clamp01(elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = endScale; // 最終位置を確定
    }

    public void MondaiRestart()
    {
        active = false;
        StopAllCoroutines();
        GetComponentInChildren<TextMeshPro>().color = Color.white;

        if (mode == 0)
        {
            transform.localScale = Vector3.zero;

        }
        else
        {
            var pos = transform.position;
            float x = CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Right);

            transform.position = new(x, pos.y, pos.z);

        }

    }

    public void MondaiHit()
    {
        //mondaiList[i].GetComponent<TextMeshPro>().enabled = false;
        GetComponentInChildren<TextMeshPro>().color = Color.gray;

        Debug.Log("HIT");

        active = false;

    }

    public void Destroy()
    {
        active = false;
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Debug.LogWarning("画面外にいる");
        //       active = false;
    }
}
