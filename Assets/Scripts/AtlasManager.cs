using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : MonoBehaviour
{
    public static AtlasManager instance;

    // インスペクターから設定するSpriteAtlas
    public SpriteAtlas spriteAtlas;

    void Awake()
    {
        // シングルトンの初期化（複数存在しない前提）
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