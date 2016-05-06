using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound
{
    public static Sound Instance
    {
        get { return instance ?? (instance = new Sound()); }
    }

    static Sound instance;

    GameObject obj;

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    AudioSource bgmAudioSource;

    AudioSource seAudioSource;

    // when fadeout audio clip, attach this script component.
    class FadeOut : MonoBehaviour
    {
        public AudioSource Source;

        public float FadeTime;

        public System.Action Callback;

        public void StartFade()
        {
            StartCoroutine(_FadeOut());
        }

        IEnumerator _FadeOut()
        {
            float defaultVolume = this.Source.volume;
            float d = this.Source.volume / (1 / Time.fixedDeltaTime) / this.FadeTime;

            while (this.Source.volume > 0)
            {
                this.Source.volume -= d;
                yield return new WaitForFixedUpdate();
            }

            this.Source.Stop();
            this.Source.volume = defaultVolume;

            if (this.Callback != null) this.Callback();
        }
    }

    public void PlayBGM(string name, bool withLoop = true)
    {
        if (this.bgmAudioSource.isPlaying) this.bgmAudioSource.Stop();

        this.bgmAudioSource.loop = withLoop;
        this.bgmAudioSource.clip = this.DetectClip(name);
        this.bgmAudioSource.Play();
    }

    public void FadeOutBGM(float time, System.Action callback)
    {
        if (!this.bgmAudioSource.isPlaying) return;

        FadeOut fadeout = this.obj.GetComponent<FadeOut>() ?? this.obj.AddComponent<FadeOut>();
        fadeout.Source = this.bgmAudioSource;
        fadeout.FadeTime = time;
        fadeout.Callback = callback;
        fadeout.StartFade();
    }

    public void PlaySE(string name)
    {
        this.seAudioSource.PlayOneShot(this.DetectClip(name));
    }

    Sound()
    {
        this.obj = new GameObject("SoundObject");
        
        Object.DontDestroyOnLoad(this.obj);

        this.bgmAudioSource = this.obj.AddComponent<AudioSource>();
        this.seAudioSource = this.obj.AddComponent<AudioSource>();
    }

    AudioClip DetectClip(string name)
    {
        if (!this.audioClips.ContainsKey(name))
        {
            AudioClip c = Resources.Load("Sound/" + name) as AudioClip;

            if (c == null) throw new UnityException("Resource Sound/" + name + " is not found");

            this.audioClips.Add(name, c);
        }

        return this.audioClips[name];
    }
}