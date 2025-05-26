using UnityEngine;

public class MenuItemDuration : SwipeMenuItem
{
    private void Start()
    {
        value = _menu.duration;
        ValueDisp(value);
        swipeThreshold = 30f; // スワイプ感度設定
    }

    protected override void HandleSwipe(float deltaX)
    {
        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 1, 10);
     
        _menu.duration = value;

        ValueDisp(value);
    }

}
