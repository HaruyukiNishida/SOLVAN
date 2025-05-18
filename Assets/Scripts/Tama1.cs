using System;
using UnityEngine;

public class Tama1 : MonoBehaviour
{
    private TamaManager _tamaManager;
    //   public UnityEvent<int,int> tamaManager_Invoke;

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

        if (moveStatus == TamaStatus.Up)
        {
            if (index < 3)
            {
                if (IsTamaStop(tamas[this.index + 1]))
                {
                    tamas[this.index + 1].SetTamaMove(TamaStatus.Up);
                }
            }
        }
        else
        {

            if (index > 0)
            {
                if (IsTamaStop(tamas[this.index - 1]))
                {
                    tamas[this.index - 1].SetTamaMove(TamaStatus.Down);
                }
            }
        }

    }

    private void FixedUpdate()
    {
        //  Debug.LogWarning($"index:{index} msts{moveStatus}");

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
                _tamaManager.DispSubTotal();
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

        //Debug.LogWarning($"index:{index} msts{moveStatus}");
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
