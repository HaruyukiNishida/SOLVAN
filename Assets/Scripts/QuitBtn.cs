using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // �A�v���I��
#endif
    }
}
