using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum AudioType
    {
        SE_Droplet
    }

    [System.Serializable]
    public struct AudioData
    {
        public AudioClip clip;
        public AudioType type;
        public bool loop;

        internal AudioSource source;

        public AudioData(AudioClip clip, AudioType type, bool loop, AudioSource source) : this()
        {
            this.clip = clip;
            this.type = type;
            this.loop = loop;
            this.source = source;
        }
    }


    public List<AudioData> bgm;             // holds every bgm in game
    public List<AudioData> soundEffect;     // holds every sound effect in game


    private void Start()
    {
        // initialize audio sources for bgm and soundeffects
        for(int i = 0; i < bgm.Count; ++i)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = bgm[i].clip;
            source.loop = bgm[i].loop;

            bgm[i] = new AudioData(bgm[i].clip, bgm[i].type, bgm[i].loop, source);
        }

        for (int i = 0; i < soundEffect.Count; ++i)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = soundEffect[i].clip;
            source.loop = soundEffect[i].loop;

            soundEffect[i] = new AudioData(soundEffect[i].clip, soundEffect[i].type, soundEffect[i].loop, source);
        }
    }

    public AudioSource GetAudioSourceByType(AudioType type)
    {
        // search in bgm
        var source = bgm.Find(data => data.type == type).source;
        if (source) return source;

        // search in sound effect
        source = soundEffect.Find(data => data.type == type).source;
        if (source) return source;

        // type not found
        return null;
    }
}
