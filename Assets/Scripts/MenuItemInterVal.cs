using UnityEngine;

public class MenuItemInterval : SwipeMenuItem
{
    float min = 0.5f;
    float max = 20.0f;

    private new void Awake()
    {
        base.Awake();
        min = _menu.interval_min;
        max = _menu.interval_max;
    }

    private void Start()
    {
        value = _menu.interval;
        ValueDisp(value);
        swipeThreshold = 10f; // スワイプ感度設定

    }

    protected override void HandleSwipe(float deltaX)
    {
        float amount = 0.5f;

        value = Mathf.Clamp(value + (deltaX > 0 ? amount : -amount), min, max);

        _menu.interval = value;

        ValueDisp(value);
    }


}


