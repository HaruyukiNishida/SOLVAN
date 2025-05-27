using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MenuItemInterval : SwipeMenuItem
{
    public float min = 0.1f;
    public float max = 10.0f;

    private new void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        value = _menu.interval;
        ValueDisp(value);
        swipeThreshold = 10f; // スワイプ感度設定
        
    }

    protected override void HandleSwipe(float deltaX)
    {
        float amount = 0.1f;

        if (deltaX > 30) amount =1.0f;

        value = Mathf.Clamp(value + (deltaX > 0 ? amount : -amount), min, max);

        _menu.interval = value;

        ValueDisp(value);
    }


}


