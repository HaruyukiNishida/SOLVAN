using UnityEngine;

public class GamingColor : MonoBehaviour
{
    private float time = 0;
    private Color blendedColor;
    private Color color1 = Color.cyan;
    private Color color2 = Color.magenta;

    public static GamingColor instance;

    // �Q�[���I�u�W�F�N�g���N�����ɌĂ΂�郁�\�b�h�iMonoBehaviour�j
    private void Awake()
    {
        // �C���X�^���X�����ݒ�̏ꍇ�̏���
        if (instance == null)
        {
            // ���̃N���X�̃C���X�^���X��ݒ�
            instance = this;
            // �V�[�����؂�ւ���Ă��I�u�W�F�N�g���j������Ȃ��悤�ɐݒ�
         //   DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���łɃC���X�^���X�����݂���ꍇ�A���̃I�u�W�F�N�g��j��
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blendedColor = Color.white;
    }

    void Update()
    {
        time += Time.deltaTime * 5; // �_�ő��x�𒲐�
        float alpha = (Mathf.Sin(time) + 1) / 2; // sin�l��0�`1�͈̔͂ɕϊ�

        if (time > 18f) time = 0;

        blendedColor = Color.Lerp(color1, color2, alpha);
    }

    public Color GetGamingColor()
    {
        return blendedColor;
    }

}
