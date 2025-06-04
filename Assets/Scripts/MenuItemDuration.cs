using UnityEngine;

public class MenuItemDuration : SwipeMenuItem
{
    float min;
    float max;

    private new void Awake()
    {
        base.Awake();
    }

    private void Start()
    { 
        min = _menu.duration_min;
        max = _menu.duration_max;
        value = _menu.duration;
        ValueDisp(value);
        swipeThreshold = 10f; // スワイプ感度設定
    }

    protected override void HandleSwipe(float deltaX)
    {
        float amount = 0.5f;

        value = Mathf.Clamp(value + (deltaX > 0 ? amount : -amount), min, max);

        _menu.duration = value;

        ValueDisp(value);
    }
}
