using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IDragHandler
{
    protected float swipeThreshold = 50f;

    public void OnDrag(PointerEventData data)
    {
        float deltaX = data.delta.x;

        if (Mathf.Abs(deltaX) > swipeThreshold)
        {
            HandleSwipe(deltaX);
        }
    }
    protected virtual void HandleSwipe(float deltaX)
    {
        Debug.Log("Swipe detected: " + deltaX);
    }

}

public abstract class SwipeMenuItem : Swipe
{
    [SerializeField] TMP_Text _text;
    private int value = 0;

    protected override void HandleSwipe(float deltaX)
    {
        if (deltaX > 0)
        {
            value++;
        }
        else
        {
            value--;
        }

        Debug.Log(value);
        if(_text!=null)
        _text.text = value.ToString();
    }

}


