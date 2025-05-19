using UnityEngine;

public class Tama2 : Tama1
{
    public override void TamaPosInit()
    {
        startPos = transform.position;
        endPos = transform.position + transform.parent.up * -1.0f;

        onPos = endPos;
        offPos = startPos;

     //   Debug.Log($"index:{index} startPos:{startPos} endPos:{endPos}");
    }

    public override void IsHitTama()
    {
    }

    public override TamaStatus GetIsOn()
    {
        return (moveStatus == TamaStatus.Down) ? TamaStatus.On : TamaStatus.Off;
    }

    public override void CheckEventTriggerDragEndSub(bool vec)
    {
        if (moveStatus == TamaStatus.On && vec)
        {
            SetTamaMove(TamaStatus.Up);
        }

        if (moveStatus == TamaStatus.Off && !vec)
        {
            SetTamaMove(TamaStatus.Down);
        }
    }

    public override void SetTamaMoveSub(TamaStatus movestatus)
    {
        startPos = this.transform.position;
        endPos = (movestatus == TamaStatus.Down) ? onPos : offPos;
    }
}
