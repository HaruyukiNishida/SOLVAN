using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Tama : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rb;

    private bool isActive;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 force = Vector3.up;
 //   private float moveSpeed = 1f;

    private int status;

    public int index;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        GetComponent<Collider>().material.bounciness = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

     //   _rb.MovePosition(_rb.position + force * moveSpeed * Time.fixedDeltaTime);


        //var speed = _rb.linearVelocity.magnitude;

        //if (speed < 0.01)
        //{
        //    Debug.LogWarning($"{this.name} : {speed}");
        //}
    }

    public void CheckEventTriggerDragBegin()
    {
        //   Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

        status = 0;
        _rb.isKinematic = false;
        startPos = Input.mousePosition;
    }




    public void CheckEventTriggerDragEnd()
    {
        //  Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

        endPos = Input.mousePosition;


        //  Debug.Log("startPos:" + startPos + " endPos:" + endPos);


        //var mode = ForceMode.Impulse;

        float vec = startPos.y - endPos.y;

        if (vec < 0)
        {
            status = 1;//ª
                       //   _rb.AddForce(force * accel, mode);
            force = Vector3.up;


        }
        else
        {
            status = 2;//«
                       //   _rb.AddForce(-force * accel, mode);
            force = Vector3.down;
        }


        Debug.Log(status);

    }


    public void CheckUpTrrigerEnter()
    {
        //  Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        if (status == 1)
        {
            KinematicFalse();
        }
    }

    private void KinematicFalse()
    {
        //  Debug.Log(this.name);
        _rb.isKinematic = true;
        StartCoroutine(KinematicFalseCoroutine());
    }

    private IEnumerator KinematicFalseCoroutine()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        status = 0;
        _rb.isKinematic = false;
    }


    public void CheckUpTrrigerExit()
    {
        //  Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void CheckDownTrrigerEnter()
    {
        //    Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //  KinematicFalse();

        if (status == 2)
        {
            KinematicFalse();
        }
    }

    public void CheckDownTrrigerExit()
    {
        //   Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

}
