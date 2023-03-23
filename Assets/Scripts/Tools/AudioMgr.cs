using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : SingletonMono<AudioMgr>
{
    GameObject audioMgr;
    AudioClip buttonAudioClip;
    AudioSource bgmAudio;
    AudioSource systemAudio;
    float allVolume;
    float bgmVolume;
    float systemVolume;

    Dictionary<string, AudioClip> bgmClip = new Dictionary<string, AudioClip>();

    public void Init()
    {
        Debug.Log("------初始化声音------");
        buttonAudioClip = Resources.Load<AudioClip>("Voice/UI/Click");
        audioMgr = new GameObject("AudioMgr");
        audioMgr.transform.SetParent(transform);

        bgmAudio = audioMgr.AddComponent<AudioSource>();

        systemAudio = audioMgr.AddComponent<AudioSource>();

        // SetAllVolume(GameSetting.TotalVolume);
        // SetBgmVolume(GameSetting.BGMVolume);
        // SetSystemVolume(GameSetting.SystemVolume);
        // MuteBgmVolume(GameSetting.BGMVolume_OnOff);
        // MuteSystemVolume(GameSetting.SystemVolume_OnOff);

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Voice/BGM");

        for (int i = 0; i < clips.Length; i++)
        {
            bgmClip.Add(clips[i].name, clips[i]);
        }

    }

    public AudioSource GetBGMAudio()
    {
        return bgmAudio;
    }

    /// <summary>
    /// 设置整体音量
    /// </summary>
    public void SetAllVolume(float soundValue)
    {
        soundValue = soundValue > 1 ? 1 : soundValue;
        soundValue = soundValue < 0 ? 0 : soundValue;
        allVolume = soundValue;
        SetBgmVolume(bgmVolume);
        SetSystemVolume(systemVolume);
    }

    /// <summary>
    /// 设置BGM音量
    /// </summary>
    public void SetBgmVolume(float soundValue)
    {
        soundValue = soundValue > 1 ? 1 : soundValue;
        soundValue = soundValue < 0 ? 0 : soundValue;
        bgmVolume = soundValue;
        float volume = soundValue * allVolume;
        bgmAudio.volume = volume;
    }
    public void MuteBgmVolume(bool mute)
    {
        bgmAudio.mute = mute;
    }

    /// <summary>
    /// 设置系统音乐音量
    /// </summary>
    public void SetSystemVolume(float soundValue)
    {
        soundValue = soundValue > 1 ? 1 : soundValue;
        soundValue = soundValue < 0 ? 0 : soundValue;
        systemVolume = soundValue;
        float volume = soundValue * allVolume;


        systemAudio.volume = volume;


    }
    public void MuteSystemVolume(bool mute)
    {
        systemAudio.mute = mute;
    }

    /// <summary>
    /// /// 播放背景音乐
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="loop"></param>
    public void PlayBGM(string BgmName, bool loop = true)
    {
        if (bgmAudio.clip != null && bgmAudio.clip.name == BgmName)
        {
            return;
        }

        AudioClip clip = bgmClip[BgmName];
        if (clip == null)
        {
            Debug.LogError("想要播放的BGM clip== null   " + BgmName);
            return;
        }
        bgmAudio.loop = loop;
        bgmAudio.clip = clip;
        bgmAudio.Play();
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (clip == null)
        {
            return;
        }
        bgmAudio.loop = loop;
        bgmAudio.clip = clip;
        bgmAudio.Play();
    }


    /// <summary>
    /// 播放UI声音
    /// </summary>
    public void PlayClickScound()
    {
        systemAudio.PlayOneShot(buttonAudioClip);
    }


    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="soundName"></param>
    public void PlaySound(string soundName,bool loop  = false)
    {
        AudioClip clip = Resources.Load<AudioClip>("Voice/UI/" + soundName);

        if (!loop)
            systemAudio?.PlayOneShot(clip);
        else
        {
            systemAudio.clip = clip;
            systemAudio.loop = true;
            systemAudio.Play();
        }
    }

    public void StopSound()
    {
        systemAudio.Stop();
    }

    public void PlaySound(AudioClip clip)
    {
        systemAudio.PlayOneShot(clip);
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        if (systemAudio == null) return;

        systemAudio.PlayOneShot(audioClip);
    }

    /// <summary>
    /// 停止所有声音
    /// </summary>
    public void StopALL()
    {
        bgmAudio.Stop();

        systemAudio.Stop();
    }

}

