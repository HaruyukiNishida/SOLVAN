using System;
using TMPro;
using UnityEngine;

public class Mondai : MonoBehaviour
{
    public int num;
    public int index;
    public bool active;
    public int mode;

    private void Start()
    {
    }




    void Update()
    {
        if (!active) return;

        if (mode == 0)
        {
            MoveLeftToRight();
        }

    }

    private void MoveLeftToRight()
    {
        if (!active) return;

        transform.Translate(-0.1f, 0f, 0f);

      //  Debug.Log($"[{index}] / {transform.position.x} / {active}");

        if (!GetComponent<SpriteRenderer>().isVisible)
        {
         //   active = false;
         //   Debug.LogWarning($"[{index}] / {transform.position.x}");

            //Destroy(gameObject);
        }

    }

    void OnBecameInvisible()
    {
       
     //       Debug.LogWarning(transform.position.x);
     //       active = false;
        

    }
}
