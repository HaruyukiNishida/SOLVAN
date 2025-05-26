using UnityEngine;

public class MenuItemMode : SwipeMenuItem
{
    private void Start()
    {
        value = _menu.mode;
        _text.text = ModeString((int)value);
        swipeThreshold = 30f; // スワイプ感度設定
    }
    
    protected override void HandleSwipe(float deltaX)
    {
        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 0, 1);

        _menu.mode=(int)value;
        _text.text = ModeString((int)value);
    }

    protected string ModeString(int mode)
    {
        return (mode == 0) ? "RandomSpawn" : "RightToLeft";
    }

}
