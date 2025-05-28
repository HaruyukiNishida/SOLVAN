using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioClip[] audioClip;

    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    //  private List<SoundList> soundList = new List<SoundList>();

    [SerializeField, Range(20, -80)] private int volume = 0;



    //シングルトン
    public static AudioManager instance;

    // ゲームオブジェクトが起動時に呼ばれるメソッド（MonoBehaviour）
    private void Awake()
    {
        // インスタンスが未設定の場合の処理
        if (instance == null)
        {
            // このクラスのインスタンスを設定
            instance = this;
            // シーンが切り替わってもオブジェクトが破棄されないように設定
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // すでにインスタンスが存在する場合、このオブジェクトを破棄
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioMixer.SetFloat("VolumeSE", volume);

        foreach (var clip in audioClip)
        {
            clips.Add(clip.name, clip);
        }
    }

    void Update()
    {
    }

    public void PlaySE(TypePlaySE clipname)
    {
        //float value;
        //audioMixer.GetFloat("VolumeSE",out value);
        //Debug.Log(value);

        Debug.Log(clipname.ToString());

        PlaySE(clipname.ToString());
    }

    public void PlaySE(string clipname)
    {
        if (clips.ContainsKey(clipname))
        {
            //   Debug.Log(clipname);
            GetComponent<AudioSource>().PlayOneShot(clips[clipname]);
        }
        else
        {
            Debug.Log("No SE");
        }
    }

    public void PlaySEcardFlip()
    {
        PlaySE("flipCard");
    }
    public void PlaySEgotchaSE()
    {
        PlaySE("WadaikoDon");
    }
    public void PlaySEgotcha2SE()
    {
        PlaySE("WadaikoDoDon");
    }

    public void PlaySEnogotcha()
    {
        PlaySE("spunch");

    }
    public void PlaySEgameOverSE()
    {
        PlaySE("vibraslap");
    }
    public void PlaySEclearSE()
    {
        PlaySE("drram");
    }
}

