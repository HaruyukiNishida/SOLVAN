using UnityEngine;

public class MenuItemDuration : SwipeMenuItem
{
    private void Awake()
    {
        swipeThreshold = 30f; // �X���C�v���x�ݒ�
    }

    protected override void HandleSwipe(float deltaX)
    {
        //base.HandleSwipe(deltaX);

        value = Mathf.Clamp(value + (deltaX > 0 ? 1 : -1), 0, 10);
        _text.text = value.ToString();
        Debug.Log("Duration changed to: " + value);
    }

}
