using UnityEngine;

public class MenuItemLevel : SwipeMenuItem
{
    private void Awake()
    {
        swipeThreshold = 30f; // スワイプ感度設定
    }

    protected override void HandleSwipe(float deltaX)
    {
        //base.HandleSwipe(deltaX);

        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 1, 3);
        _text.text = value.ToString();
        Debug.Log("Level changed to: " + value);
    }

}
