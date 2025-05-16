using System.Reflection;
using UnityEngine;

public class Tama2 : Tama1
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override TamaStatus GetIsOn()
    {
        Debug.LogWarning(MethodBase.GetCurrentMethod().Name);

        Debug.Log(moveStatus == TamaStatus.Down);

        return (moveStatus == TamaStatus.Down) ? TamaStatus.On : TamaStatus.Off;
    }

    public override void CheckEventTriggerDragEndSub(TamaStatus movestatus)
    {
        SetTamaMove(movestatus);
    }

    public override bool SetTamaMoveSub(TamaStatus movestatus)
    {
     //   Debug.LogWarning(MethodBase.GetCurrentMethod().Name);
     //   Debug.Log($"{movestatus} {isOn}");

        return (movestatus == TamaStatus.Down && !isOn || movestatus == TamaStatus.Up && isOn);
    }
}
