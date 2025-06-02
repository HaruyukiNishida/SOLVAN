using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipe : MonoBehaviour, IDragHandler
{
    protected float swipeThreshold = 10f;

    public void OnDrag(PointerEventData data)
    {
        float deltaX = data.delta.x;
        Debug.Log(data.clickTime);

        if (Mathf.Abs(deltaX) > swipeThreshold)
        {
            HandleSwipe(deltaX);
        }
    }
    protected virtual void HandleSwipe(float deltaX)
    {
        //Debug.Log("Swipe detected: " + deltaX);
    }
}

public abstract class SwipeMenuItem : Swipe
{
    [SerializeField] protected TMP_Text _text;
    protected Menu _menu;

    protected float value = 0;
    protected void Awake()
    {
        _menu = FindFirstObjectByType<Menu>();
    }

    protected override void HandleSwipe(float deltaX)
    {
        ValueDisp(value);
    }

    protected virtual void ValueDisp(float value)
    {
        _text.text = value.ToString("F1");
    }

    protected virtual void ValueDisp(int value)
    {
        _text.text = value.ToString();
    }


}


