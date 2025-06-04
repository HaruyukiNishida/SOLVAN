using System.Collections;
using UnityEngine;

public class MenuItemLevel : SwipeMenuItem
{
    private new void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        value = _menu.level;
        ValueDisp((int)value+1);
    //    swipeThreshold = 30f; // スワイプ感度設定
    }

    protected override void HandleSwipe(float deltaX)
    {
        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 0, 9);

        _menu.level = (int)value;

        ValueDisp((int)value+1);

    }

}
