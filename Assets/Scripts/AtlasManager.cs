using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : MonoBehaviour
{
    public static AtlasManager instance;

    // �C���X�y�N�^�[����ݒ肷��SpriteAtlas
    public SpriteAtlas spriteAtlas;

    void Awake()
    {
        // �V���O���g���̏������i�������݂��Ȃ��O��j
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}