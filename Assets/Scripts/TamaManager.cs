using UnityEngine;

public class TamaManager : MonoBehaviour
{
    public static TamaManager instance;

    public Tama1[] tamas;

    public int keta = 1;

    private void Awake()
    {
        // �C���X�^���X�����ݒ�̏ꍇ�̏���
        if (instance == null)
        {
            // ���̃N���X�̃C���X�^���X��ݒ�
            instance = this;
            // �V�[�����؂�ւ���Ă��I�u�W�F�N�g���j������Ȃ��悤�ɐݒ�
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���łɃC���X�^���X�����݂���ꍇ�A���̃I�u�W�F�N�g��j��
            Destroy(gameObject);
        }

        tamas = new Tama1[5];

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTamas(Tama1 tama, int index)
    {
        tamas[index] = tama;

    }

    public void MoveTamas(int index, int movestatus)
    {
        if (movestatus == 1)
        {
            for (int i = index; i <= 3; i++)
            {

                tamas[i].SetTamaMove(movestatus);
            }
        }
        else
        {
            for (int i = index; i >= 0; i--)
            {
                //  if (!tamas[i].isOn)
                {
                    tamas[i].SetTamaMove(movestatus);
                }
            }

        }
    }






}
