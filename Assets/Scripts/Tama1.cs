using System;
using System.Reflection;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class Tama1 : MonoBehaviour
{
    private Transform _transform;

    private TamaManager _tamaManager;
    //   public UnityEvent<int,int> tamaManager_Invoke;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 onPos;
    private Vector3 offPos;

    private Vector3 swipeStartPos;
    private Vector3 swipeEndPos;

    private float timer = 0f;
    private float speed = 0.5f;
    private float distance = 1.0f;
    public float rate;

    public int index;
    public bool isOn;

    public TamaStatus moveStatus = TamaStatus.Off;



    void Awake()

    {
        _transform = transform;
        startPos = _transform.localPosition;
        endPos = _transform.localPosition + Vector3.up * 1.0f;

        onPos = endPos;
        offPos = startPos;

        //   Debug.Log($"Awake index:{index} startPos:{startPos} endPos:{endPos}");

        _tamaManager = GetComponentInParent<TamaManager>();
    }

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
                Debug.Log("this:" + moveStatus + " hitTama:" + hitTama.moveStatus);

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

    private void FixedUpdate()
    {
      //  Debug.LogWarning($"index:{index} msts{moveStatus}");


        if (!IsTamaStop())
        {
            timer += Time.deltaTime;
            rate = timer * speed / distance;
            if (rate >= 1)
            {
                isOn = this.GetIsOn();
                moveStatus = isOn ? TamaStatus.On : TamaStatus.Off;

                transform.localPosition = endPos;
                _tamaManager.DispSubTotal();
            }
            else
            {
                transform.position = Vector3.Lerp(startPos, endPos, rate);
            }
        }
    }

    public virtual bool GetIsOn()
    {
        return this.isOn = (moveStatus == TamaStatus.Up);
    }

    public void CheckEventTriggerDragBegin()
    {
        if (IsTamaStop()) return;

        swipeStartPos = Input.mousePosition;

    }

    public void CheckEventTriggerDragEnd()
    {
        if (IsTamaStop()) return;

        //    Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

        swipeEndPos = Input.mousePosition;
        float vec = swipeStartPos.y - swipeEndPos.y;

        CheckEventTriggerDragEndSub((vec < 0) ? TamaStatus.Up : TamaStatus.Down);
    }

    public virtual void CheckEventTriggerDragEndSub(TamaStatus movestatus)
    {
        //SetTamaMove(movestatus);
        _tamaManager.MoveTamas(index, movestatus);
    }


    public void SetTamaMove(TamaStatus movestatus)
    {
        if (SetTamaMoveSub(movestatus))
        {
            Debug.Log("SetMoveTama");

            moveStatus = movestatus;

            startPos = this.transform.localPosition;
            timer = 0f;
            rate = 0f;

            //   endPos = startPos + ((movestatus == TamaStatus.Up) ? Vector3.up : Vector3.down) * distance;
            endPos = (movestatus == TamaStatus.Up) ? onPos : offPos;
        }
        else
        {
            //   moveStatus = TamaStatus.Stop;
        }

        //   Debug.Log($"index:{index} startPos:{startPos} endPos:{endPos}");
    }

    public virtual bool SetTamaMoveSub(TamaStatus movestatus)
    {
        return (movestatus == TamaStatus.Up && !isOn || movestatus == TamaStatus.Down && isOn);
    }

    public bool IsTamaStop()
    {
        return (moveStatus == TamaStatus.Off || moveStatus == TamaStatus.On);

    }



    public void CheckUpTrrigerEnter(Collider collider)
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        if (moveStatus == TamaStatus.Up)
        {
            //   collider.gameObject.GetComponent<Tama1>().moveStatus=1;
        }
    }



    public void CheckDownTrrigerEnter(Collider collider)
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        if (moveStatus == TamaStatus.Down)
        {

            //  collider.gameObject.GetComponent<Tama1>().moveStatus = 2;
        }
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
