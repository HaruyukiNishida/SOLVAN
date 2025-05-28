using System;
using UnityEngine;

public class Tama1 : MonoBehaviour
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


    void Awake()
    {
        TamaPosInit();

        _tamaManager = GetComponentInParent<TamaManager>();
        _vanManager = GetComponentInParent<VanManager>();
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

    private void FixedUpdate()
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
                }
            }
        }
    }

    public virtual TamaStatus GetIsOn()
    {
        return (moveStatus == TamaStatus.Up) ? TamaStatus.On : TamaStatus.Off;
    }

    public void CheckEventTriggerDragBegin()
    {
        if (!IsTamaStop(this)) return;

        swipeStartPos = Input.mousePosition;
        Input.GetTouch(0);
    }

    public void CheckEventTriggerDragEnd()
    {
        if (!IsTamaStop(this)) return;

        swipeEndPos = Input.mousePosition;
        float vec = swipeStartPos.y - swipeEndPos.y;

        CheckEventTriggerDragEndSub((vec < 0));
    }

    public virtual void CheckEventTriggerDragEndSub(bool vec)
    {
        if (moveStatus == TamaStatus.Off && vec)
        {
            SetTamaMove(TamaStatus.Up);

        }

        if (moveStatus == TamaStatus.On && !vec)
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
