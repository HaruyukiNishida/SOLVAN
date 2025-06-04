using System.Collections;
using TMPro;
using UnityEngine;

public partial class Mondai : MonoBehaviour
{
    [SerializeField]GameObject _hitEffect;

    GameDirector _gameDirector;
    Menu _menu;

    Suji _suji;
    TMP_Text _tmpTxt;

    public int num;
    public MondaiStatus status;

    private int mode;
    private float duration;

    private Color defaultColor = Color.white + new Color32(0, 0, 0, 255);
    private Color alphaColor = new Color32(0, 0, 0, 16);

    private void Awake()
    {
        _tmpTxt = GetComponentInChildren<TextMeshPro>();

        if (_tmpTxt != null)
        {
         //   _tmpTxt.enabled = false;
        }

        _suji = GetComponentInChildren<Suji>();

        if (_suji != null)
        {
            _suji.enabled = false;
        }
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

    public void MondaiInit()
    {
        if (_suji != null)
        { 
            _suji.SetSprite(num);
            SujiAlpha(false);
        }

        if (_tmpTxt != null)
        {
            _tmpTxt.text = num.ToString();
            _tmpTxt.color = defaultColor;
        }

        mode = _menu.mode;
        duration = _menu.duration;

    }

    public void MoveRightToLeft()
    {
        MondaiInit();
        status = MondaiStatus.Active;

        SujiAlpha(true);
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
        _gameDirector.CountUp(num);

    }

    public void Scaling()
    {
        MondaiInit();
        status = MondaiStatus.Active;

        SujiAlpha(true);
        mode = 0;

        Vector3 startScale = new Vector3(0.5f, 0.5f, 1f); ;
        Vector3 endScale = new Vector3(2f, 2f, 1f);

        StartCoroutine(ScalingSub(startScale, endScale));
    }

    public IEnumerator ScalingSub(Vector3 startScale, Vector3 endScale)
    {
        float elapsed = 0f;

        while (elapsed < duration && status == MondaiStatus.Active)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, Mathf.Clamp01(elapsed / duration));

             //  transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0f, 1080f, Mathf.Clamp01(elapsed / duration)));

            elapsed += Time.deltaTime;
            yield return null;
        }

        //   transform.localScale = endScale; // 最終位置を確定
        status = MondaiStatus.Gone;
        _suji.setAlpha(false);

        _gameDirector.CountUp(num);


    }

    public void MondaiRestart()
    {
        status = MondaiStatus.StandBy;
        StopAllCoroutines();

        if (_tmpTxt != null)
        {
            _tmpTxt.color = defaultColor;
        }

        if(_suji!=null)
        {
            SujiAlpha(false);


        }


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
        status = MondaiStatus.Gone;
        AudioManager.instance.PlaySE(TypePlaySE.spunch);

        if(_hitEffect != null)
        {
            Instantiate(_hitEffect, transform.position, Quaternion.identity);
        }

        if (_tmpTxt != null)
        {
            _tmpTxt.color = Color.black;
            StartCoroutine(MondaiGoneSub());
        }

        if (_suji != null)
        {
            StartCoroutine(MondaiGoneSub2());
        }

    }

    IEnumerator MondaiGoneSub()
    {
        var color = _tmpTxt.color;

        for (int i = 255; i >= 0; i -= 16)
        {
            color -= alphaColor;
            _tmpTxt.color = color;

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator MondaiGoneSub2()
    {
        var sprites = _suji.GetSprites();


        for (int i = 255; i >= 0; i -= 16)
        {
            foreach (var sprite in sprites)
            {

                if (sprite.gameObject.activeSelf)
                {
                    var color = sprite.color;
                    sprite.color -= alphaColor;

                }


            }
            yield return new WaitForSeconds(0.01f);

        }
    }

    public void SujiAlpha(bool visible)
    {
        _suji.setAlpha(visible);
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
