using UnityEngine;

public class MenuItemDuration : SwipeMenuItem
{
    float min = 0.5f;
    float max = 20.0f;

    private new void Awake()
    {
        base.Awake();
        min = _menu.duration_min;
        max = _menu.duration_max;
    }

    private void Start()
    {
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
