using System.Collections;
using TMPro;
using UnityEngine;

public partial class Mondai : MonoBehaviour
{
    [SerializeField] GameDirector _gameDirector;
    [SerializeField] Menu _menu;

    private TMP_Text tmpTxt;

    public int num;
    public MondaiStatus status;
    private int mode;
    private float duration;

    private Color defaultColor = Color.white + new Color32(0, 0, 0, 255);
    private Color alphaColor = new Color32(0, 0, 0, 16);

    private void Awake()
    {
        tmpTxt = GetComponentInChildren<TextMeshPro>();
        tmpTxt.color = Color.white;
        tmpTxt.enabled = false;

    }



    void Update()
    {


    }

    public void DependencyInjection(GameDirector gd)
    {
        _gameDirector = gd;
    }
    public void DependencyInjection(Menu menu)
    {
        _menu = menu;
    }

    private void MondaiInit()
    {
        tmpTxt.text = num.ToString();
        tmpTxt.color = defaultColor;
        tmpTxt.enabled = true;

        mode = _menu.mode;
        duration = _menu.duration;

        status = MondaiStatus.Active;

    }

    public void MoveRightToLeft()
    {
        MondaiInit();
        mode = 1;

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(CamPoint.Instance.GetBorder(CamPoint.TypeBorders.Left), startPos.y, startPos.z);

        StartCoroutine(MoveRightToLeftSub(startPos, endPos));
    }

    public IEnumerator MoveRightToLeftSub(Vector3 startPos, Vector3 endPos)
    {
        float elapsed = 0f;

        while (elapsed < duration && status == MondaiStatus.Active)
        {
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(elapsed / duration));

            //   transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0f, 1080f, Mathf.Clamp01(elapsed / duration)));

            elapsed += Time.deltaTime;
            yield return null;
        }
        //    transform.position = endPos; // 最終位置を確定
        status = MondaiStatus.Gone;
        _gameDirector.CountUp();

    }

    public void Scaling()
    {
        MondaiInit();
        mode = 0;

        Vector3 startScale = transform.localScale;
        Vector3 endScale = new Vector3(2f, 2f, 1f);

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

        //   transform.localScale = endScale; // 最終位置を確定
        status = MondaiStatus.Gone;
        _gameDirector.CountUp();


    }

    public void MondaiRestart()
    {
        status = MondaiStatus.StandBy;
        StopAllCoroutines();


        tmpTxt.color = defaultColor;

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

    public void MondaiGone()
    {
        AudioManager.instance.PlaySE(TypePlaySE.spunch);

        tmpTxt.color = Color.black;

        status = MondaiStatus.Gone;

        StartCoroutine(MondaiGoneSub());

    }

    IEnumerator MondaiGoneSub()
    {
        var color = tmpTxt.color;

        for (int i = 255; i >= 0; i -= 16)
        {
            color -= alphaColor;
            tmpTxt.color = color;

            yield return new WaitForSeconds(0.01f);
        }

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
