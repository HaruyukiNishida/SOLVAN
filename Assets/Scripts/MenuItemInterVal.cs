using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MenuItemInterval : SwipeMenuItem
{
    
    private void Start()
    {
        value = _menu.interval;
        ValueDisp(value);
        swipeThreshold = 30f; // スワイプ感度設定
        
    }

    protected override void HandleSwipe(float deltaX)
    {
        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 0, 10);
     
        _menu.interval = value;

        ValueDisp(value);
    }


}


