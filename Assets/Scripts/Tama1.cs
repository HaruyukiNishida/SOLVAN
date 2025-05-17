using System;
using UnityEngine;

public class Tama1 : MonoBehaviour
{
    private TamaManager _tamaManager;
    //   public UnityEvent<int,int> tamaManager_Invoke;

    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 onPos;
    public Vector3 offPos;

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
        startPos = transform.localPosition;
        endPos = transform.localPosition + Vector3.up * 1.0f;

        onPos = endPos;
        offPos = startPos;



    }

    /*
    void Update()
    {
        if (IsTamaStop()) return;

        var hitTama = IsHitTama();

        if (hitTama != null)
        {
            //Debug.LogWarning("H I T: " + hitTama);

            //Debug.LogWarning($"{moveStatus}: {hitTama.moveStatus}");

            if (rate > hitTama.rate)
            {
                Debug.Log("hitTama");
                hitTama.SetTamaMove(this.moveStatus);
            }
            else
            {
                Debug.Log($"[{index}] moveStatus:{moveStatus} /  [{hitTama.index}] moveStatus:{hitTama.moveStatus}");

                this.moveStatus = hitTama.moveStatus;
                this.SetTamaMove(hitTama.moveStatus);
            }

        }
    }

    private Tama1 IsHitTama()
    {
        if (IsTamaStop()) return null;

        var tamas = _tamaManager.GetTamas();

        for (int i = 0; i < tamas.Length; i++)
        {

            if (i != index)
            {
                if (Math.Abs(transform.localPosition.y - tamas[i].transform.localPosition.y) < 1
                    && this.moveStatus != tamas[i].moveStatus)
                {
                    return tamas[i];
                }

            }


        }
        return null;
    }
    */
    private void FixedUpdate()
    {
        //  Debug.LogWarning($"index:{index} msts{moveStatus}");

        if (!IsTamaStop())
        {
            timer += Time.deltaTime;
            rate = Mathf.Clamp01(timer * speed / distance);
            if (rate < 1)
            {
                transform.position = Vector3.Lerp(startPos, endPos, rate);

            }
            else
            {
                moveStatus = GetIsOn();

                transform.localPosition = endPos;
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
        if (!IsTamaStop()) return;

        swipeStartPos = Input.mousePosition;

    }

    public void CheckEventTriggerDragEnd()
    {
        if (!IsTamaStop()) return;

        swipeEndPos = Input.mousePosition;
        float vec = swipeStartPos.y - swipeEndPos.y;

        CheckEventTriggerDragEndSub((vec < 0));
    }

    public virtual void CheckEventTriggerDragEndSub(bool vec)
    {
        if (moveStatus == TamaStatus.Off && vec)
        {
            _tamaManager.MoveTamas(index, TamaStatus.Up);

        }

        if (moveStatus == TamaStatus.On && !vec)
        {
            _tamaManager.MoveTamas(index, TamaStatus.Down);

        }
    }


    public void SetTamaMove(TamaStatus movestatus)
    {
        SetTamaMoveSub(movestatus);

        timer = 0f;
        rate = 0f;

        moveStatus = movestatus;

        //Debug.LogWarning($"index:{index} msts{moveStatus}");
    }

    public virtual void SetTamaMoveSub(TamaStatus movestatus)
    {
        startPos = this.transform.localPosition;
        endPos = (movestatus == TamaStatus.Up) ? onPos : offPos;
    }




    public bool IsTamaStop()
    {
        return (moveStatus == TamaStatus.Off || moveStatus == TamaStatus.On);
    }


    public void CheckUpTrrigerEnter(Collider collider)
    {
        //Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

    }

    public void CheckDownTrrigerEnter(Collider collider)
    {
        //Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
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
