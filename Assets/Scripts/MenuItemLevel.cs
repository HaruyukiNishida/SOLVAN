using UnityEngine;

public class MenuItemLevel : SwipeMenuItem
{
    private void Start()
    {
        value = _menu.duration;
        ValueDisp((int)value);
        swipeThreshold = 30f; // �X���C�v���x�ݒ�
    }

    protected override void HandleSwipe(float deltaX)
    {
        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 1, 3);

        _menu.level = (int)value;

        ValueDisp((int)value);
    }

}
