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
    [SerializeField] protected TMP_Text _text;
    [SerializeField] protected Menu _menu;

    protected float value = 0;
    private void Awake()
    {
        _menu = FindFirstObjectByType<Menu>();
    }

    protected override void HandleSwipe(float deltaX)
    {
        ValueDisp(value);
    }

    protected virtual void ValueDisp(float value)
    {
        _text.text = value.ToString();
    }

}


