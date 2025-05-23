using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
        duration = 3f;
    }




    void Update()
    {


    }

    public void MoveRightToLeft()
    {
        //    if (!active) return;

        
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Left), startPos.y, startPos.z);

        StartCoroutine(MoveRightToLeftSub(startPos, endPos));
    }

    IEnumerator MoveRightToLeftSub(Vector3 startPos, Vector3 endPos)
    {
        /*
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            //   active = false;
            //   Destroy(gameObject);
            Debug.LogWarning("画面外にいる");
        }
        */
     //   Debug.Log($"{index}/{active}");

        float elapsed = 0f;

          Debug.Log($"{elapsed}/{duration}");

        while (elapsed < duration)
    //        while (true)
        {
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(elapsed / duration));
            elapsed += Time.deltaTime;

         //   Debug.Log($"[{index}]/{startPos}/{endPos}/{elapsed}");

            
            yield return null;
        }
        transform.position = endPos; // 最終位置を確定
        Debug.Log($"{index}/End");
    }

    void OnBecameInvisible()
    {
        Debug.LogWarning("画面外にいる");

        //       active = false;
    }
}
