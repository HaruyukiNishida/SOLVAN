using UnityEngine;

public class MenuItemType : SwipeMenuItem
{
    private void Awake()
    {
        swipeThreshold = 30f; // スワイプ感度設定
    }
    
    protected override void HandleSwipe(float deltaX)
    {
        //base.HandleSwipe(deltaX);

        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 0, 1);
        
        _text.text = value.ToString();
        Debug.Log("Type changed to: " + value);
    }

}
