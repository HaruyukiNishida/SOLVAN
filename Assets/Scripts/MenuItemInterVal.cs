using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MenuItemInterval : SwipeMenuItem
{
    
    private void Awake()
    {
        swipeThreshold = 30f; // スワイプ感度設定
    }

    protected override void HandleSwipe(float deltaX)
    {
        

        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 0, 10);
     //   _text.text = value.ToString();
     //   Debug.Log("Interval changed to: " + value);
     
        base.HandleSwipe(deltaX);
    }


}


