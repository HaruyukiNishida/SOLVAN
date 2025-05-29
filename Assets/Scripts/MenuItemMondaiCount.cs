using UnityEngine;

public class MenuItemMondaiCount : SwipeMenuItem
{
    public float min = 5f;
    public float max = 20f;

    private new void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        value = _menu.mondaiCount;
        ValueDisp((int)value);
      //  swipeThreshold = 40f; // スワイプ感度設定
    }

    protected override void HandleSwipe(float deltaX)
    {
        //Debug.Log(deltaX);

        float amount =5f;

        value = Mathf.Clamp(value + (deltaX > 0 ? amount : -amount), min, max);

        _menu.mondaiCount = (int)value;

        ValueDisp((int)value);
    }

}
