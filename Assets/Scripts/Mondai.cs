using System.Collections;
using TMPro;
using UnityEngine;

public partial class Mondai : MonoBehaviour
{
    [SerializeField]GameDirector _gameDirector;

    public int num;
    public int index;
    public MondaiStatus status;
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
        status = MondaiStatus.Active;

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Left), startPos.y, startPos.z);


        StartCoroutine(MoveRightToLeftSub(startPos, endPos));
    }

    public IEnumerator MoveRightToLeftSub(Vector3 startPos, Vector3 endPos)
    {
        float elapsed = 0f;

        while (elapsed < duration && status==MondaiStatus.Active)
        {
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(elapsed / duration));

         //   transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0f, 1080f, Mathf.Clamp01(elapsed / duration)));

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos; // 最終位置を確定
        status = MondaiStatus.Gone;
        _gameDirector.CountUp();

    }

    public void Scaling()
    {
        mode = 0;
        status = MondaiStatus.Active;

        Vector3 startScale = transform.localScale;
        Vector3 endScale = new Vector3(2f,2f,1f);

        StartCoroutine(ScalingSub(startScale, endScale));

    }

    public IEnumerator ScalingSub(Vector3 startScale, Vector3 endScale)
    {
        float elapsed = 0f;

        while (elapsed < duration && status == MondaiStatus.Active)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, Mathf.Clamp01(elapsed / duration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale; // 最終位置を確定
        status = MondaiStatus.Gone;
        _gameDirector.CountUp();


    }

    public void MondaiRestart()
    {
        status = MondaiStatus.StandBy;
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

        status = MondaiStatus.Gone;
        _gameDirector.CountUp();
    }

    public void Destroy()
    {
        status = MondaiStatus.StandBy;
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Debug.LogWarning("画面外にいる");
        //       active = false;
    }
}
