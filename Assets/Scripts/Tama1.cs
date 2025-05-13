using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

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
    private bool isActive;

    public int moveStatus = 0;


    void Awake()
    {
        _transform = transform;
        startPos = transform.position;
    }

    //   void Update(){}


    private void FixedUpdate()
    {
        //   Debug.Log(moveStatus);

        if (moveStatus != 0)
        {
            timer += Time.deltaTime;
            var rate = timer * speed / distance;
            if (rate >= 1)
            {

                isOn = (moveStatus == 1);
                moveStatus = 0;

                transform.position = endPos;
            }
            else
            {
                transform.position = Vector3.Lerp(startPos, endPos, rate);
            }
        }
    }

    public void CheckEventTriggerDragBegin()
    {
        Debug.LogWarning(MethodBase.GetCurrentMethod().Name);
        if (moveStatus == 0)
        {
            //    Debug.LogWarning(isOn);
            swipeStartPos = Input.mousePosition;
        }
    }

    public void CheckEventTriggerDragEnd()
    {
        Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

        swipeEndPos = Input.mousePosition;
        float vec = swipeStartPos.y - swipeEndPos.y;

        TamaManager.instance.MoveTamas(index, (vec < 0) ? 1 : 2);

    }

    public void SetTamaMove(int movestatus)
    {
        if (movestatus == 1 && !isOn || movestatus == 2 && isOn)
        {
            moveStatus = movestatus;

            startPos = this.transform.position;
            timer = 0f;

            endPos = startPos + ((movestatus == 1) ? Vector3.up : Vector3.down) * distance;
        }
        else
        {
            moveStatus = 0;
        }
    }

    public void CheckUpTrrigerEnter(Collider collider)
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        if (moveStatus == 1)
        {

            //   collider.gameObject.GetComponent<Tama1>().moveStatus=1;
        }
    }

    public void CheckUpTrrigerExit()
    {
        //  Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void CheckDownTrrigerEnter(Collider collider)
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

        if (moveStatus == 2)
        {

            //  collider.gameObject.GetComponent<Tama1>().moveStatus = 2;
        }
    }

    public void CheckDownTrrigerExit()
    {
        //   Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
}
