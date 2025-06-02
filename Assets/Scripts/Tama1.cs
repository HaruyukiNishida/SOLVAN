using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tama1 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private TamaManager _tamaManager;
    private VanManager _vanManager;

    protected Vector3 startPos;
    protected Vector3 endPos;
    protected Vector3 onPos;
    protected Vector3 offPos;

    private Vector3 swipeStartPos;
    private Vector3 swipeEndPos;

    private float timer = 0f;
    private float speed = 10f;
    private float distance = 1.0f;
    public float rate;

    public int index;

    public TamaStatus moveStatus = TamaStatus.Off;

    AudioSource _audioSource;
    [SerializeField] AudioClip click1;
    [SerializeField] AudioClip click2;

    void Awake()
    {
        TamaPosInit();

        _tamaManager = GetComponentInParent<TamaManager>();
        _vanManager = GetComponentInParent<VanManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    public virtual void TamaPosInit()
    {
        startPos = transform.position;
        endPos = transform.position + transform.parent.up * 1.0f;

        onPos = endPos;
        offPos = startPos;
    }

    public virtual void IsHitTama()
    {
        var tamas = _tamaManager.GetTamas();

        if (moveStatus == TamaStatus.Down)
        {
            if (index < 3)
            {
                if (IsTamaStop(tamas[this.index + 1]))
                {
                    tamas[this.index + 1].SetTamaMove(TamaStatus.Down);
                }
            }
        }
        else
        {
            if (index > 0)
            {
                if (IsTamaStop(tamas[this.index - 1]))
                {
                    tamas[this.index - 1].SetTamaMove(TamaStatus.Up);
                }
            }
        }
    }

    private void Update()
    {
        if (!IsTamaStop(this))
        {
            timer += Time.deltaTime;
            rate = Mathf.Clamp01(timer * speed / distance);
            if (rate < 1)
            {
                IsHitTama();

                transform.position = Vector3.Lerp(startPos, endPos, rate);
            }
            else
            {


                moveStatus = GetIsOn();

                transform.position = endPos;

                if (_tamaManager.IsTamasStop())
                {
                    _vanManager.UpdateTotal();
                    _audioSource.PlayOneShot((moveStatus == TamaStatus.On) ? click1 : click2);
                }


            }
        }
    }

    public virtual TamaStatus GetIsOn()
    {
        return (moveStatus == TamaStatus.Up) ? TamaStatus.On : TamaStatus.Off;
    }


    public void OnBeginDrag(PointerEventData data)
    {
        if (!IsTamaStop(this)) return;

        swipeStartPos = data.position;
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log(data.delta.y);

        if (Mathf.Abs(data.delta.y) > 10)
        {
            CheckEventTriggerDragEndSub((data.delta.y > 0));
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        //  CheckEventTriggerDragEnd();
    }

    public virtual void CheckEventTriggerDragEndSub(bool deltaY)
    {
        if (moveStatus == TamaStatus.Off && deltaY)
        {
            SetTamaMove(TamaStatus.Up);
        }

        if (moveStatus == TamaStatus.On && !deltaY)
        {
            SetTamaMove(TamaStatus.Down);
        }
    }


    public void SetTamaMove(TamaStatus movestatus)
    {
        SetTamaMoveSub(movestatus);

        timer = 0f;
        rate = 0f;
        distance = Math.Abs(startPos.y - endPos.y);

        moveStatus = movestatus;
    }

    public virtual void SetTamaMoveSub(TamaStatus movestatus)
    {
        startPos = transform.position;
        endPos = (movestatus == TamaStatus.Up) ? onPos : offPos;
    }

    public bool IsTamaStop(Tama1 tgt)
    {
        return (tgt.moveStatus == TamaStatus.Off || tgt.moveStatus == TamaStatus.On);
    }

    public void SetPositionTama(bool isOn)
    {
        if (isOn)
        {
            transform.position = onPos;
            moveStatus = TamaStatus.On;
        }
        else
        {
            transform.position = offPos;
            moveStatus = TamaStatus.Off;
        }
    }

    public void CheckUpTrrigerEnter(Collider collider)
    {
        //   Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    public void CheckDownTrrigerEnter(Collider collider)
    {
        //   Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    public void CheckUpTrrigerExit()
    {
        //  Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
    public void CheckDownTrrigerExit()
    {
        //   Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
}
