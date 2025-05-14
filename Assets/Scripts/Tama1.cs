using System.Reflection;
using UnityEngine;

public class Tama1 : MonoBehaviour
{
    private Transform _transform;

    //   public UnityEvent<int,int> tamaManager_Invoke;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 swipeStartPos;
    private Vector3 swipeEndPos;

    private float timer = 0f;
    private float speed = 10f;
    private float distance = 1.0f;

    public int index;
    public bool isOn;

    public TamaStatus moveStatus = TamaStatus.Stop;

    private bool isActive;


    void Awake()

    {
        _transform = transform;
        startPos = transform.position;
    }

    //   void Update(){}


    private void FixedUpdate()
    {

        if (moveStatus != TamaStatus.Stop)
        {
            timer += Time.deltaTime;
            var rate = timer * speed / distance;
            if (rate >= 1)
            {
                isOn = this.GetIsOn();
                moveStatus = 0;

                transform.position = endPos;
                TamaManager.instance.DispSubTotal();

                transform.position = endPos;
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
        Debug.LogWarning(MethodBase.GetCurrentMethod().Name);
        if (moveStatus == 0)
        {
            swipeStartPos = Input.mousePosition;
        }
    }

    public void CheckEventTriggerDragEnd()
    {
        Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

        swipeEndPos = Input.mousePosition;
        float vec = swipeStartPos.y - swipeEndPos.y;

        CheckEventTriggerDragEndSub((vec < 0) ? TamaStatus.Up : TamaStatus.Down);
    }

    public virtual void CheckEventTriggerDragEndSub(TamaStatus movestatus)
    {
        TamaManager.instance.MoveTamas(index, movestatus);
    }


    public void SetTamaMove(TamaStatus movestatus)
    {
        if (SetTamaMoveSub(movestatus))
        {
            moveStatus = movestatus;

            startPos = this.transform.position;
            timer = 0f;

            endPos = startPos + ((movestatus == TamaStatus.Up) ? Vector3.up : Vector3.down) * distance;
        }
        else
        {
            moveStatus = TamaStatus.Stop;
        }
    }

    public virtual bool SetTamaMoveSub(TamaStatus movestatus)
    {
        return (movestatus == TamaStatus.Up && !isOn || movestatus == TamaStatus.Down && isOn);
    }

    

    public void SetTamaMove(int movestatus)
    {
        startPos = this.transform.position;
        timer = 0f;

        endPos = startPos + ((movestatus == 1) ? Vector3.up : Vector3.down) * distance;
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
