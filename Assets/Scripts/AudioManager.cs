using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioClip[] _audioClip;
 [SerializeField, Range(20, -80)] private int volume = 0;

    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
    private AudioSource _audioSource;
    //  private List<SoundList> soundList = new List<SoundList>();

   



    //�V���O���g��
    public static AudioManager instance;

    // �Q�[���I�u�W�F�N�g���N�����ɌĂ΂�郁�\�b�h�iMonoBehaviour�j
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
    }

    void Start()
    {
        _audioMixer.SetFloat("VolumeSE", volume);
        _audioSource = GetComponent<AudioSource>();

        foreach (var clip in _audioClip)
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
            _audioSource.PlayOneShot(clips[clipname]);
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

