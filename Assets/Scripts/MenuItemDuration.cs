using UnityEngine;

public class MenuItemDuration : SwipeMenuItem
{
    private void Start()
    {
        value = _menu.duration;
        ValueDisp(value);
        swipeThreshold = 30f; // �X���C�v���x�ݒ�
    }

    protected override void HandleSwipe(float deltaX)
    {
        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 1, 10);
     
        _menu.duration = value;

        ValueDisp(value);
    }

}
