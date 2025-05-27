using UnityEditor;
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
        ValueDisp((int)value);
      //  swipeThreshold = 40f; // スワイプ感度設定
    }

    protected override void HandleSwipe(float deltaX)
    {
        Debug.Log(deltaX);

        switch ((int)_menu.level)
        {
            case 1:
                value = (deltaX > 0 ? 2 : 1);
                break;
            case 2:
                value = (deltaX > 0 ? 3 : 1);
                break;
            case 3:
                value = (deltaX > 0 ? 3 : 2);
                break;

        }

        _menu.level = (int)value;

        ValueDisp((int)value);
    }

}
