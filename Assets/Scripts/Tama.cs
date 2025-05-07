using UnityEngine;
using System.Reflection;

[RequireComponent(typeof(Rigidbody))]

public class Tama : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rb;

    private bool isActive;

    private Vector3 startPos;
    private Vector3 endPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckEventTriggerDrag()
    {
        Debug.LogWarning("Tama");


        Vector3 vec3 = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;

            float vec = startPos.y - endPos.y;
            if (vec < 0)
            {
                _rb.AddForce(0, 1, 0);
            }
            else
            {
                _rb.AddForce(0, -1, 0);
            }
        }

    }


    public void CheckUpTrrigerEnter()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public void CheckUpTrrigerExit()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

    }

    public void CheckDownTrrigerEnter()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

    }

    public void CheckDownTrrigerExit()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

    }

}
