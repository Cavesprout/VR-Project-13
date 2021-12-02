using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public IEnumerator PlaySounds(List<string> names)
    {
        foreach (string name in names)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning($"Tried to play sound {s}, which does not exist.");
                continue;
            }
            Debug.Log($"Playing sound {name} from group.");
            s.source.Play();

            while (s.source.isPlaying)
            {
                yield return null;
            }
        }
    }

    public void PlayStage0()
    {

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Tried to play sound {s}, which does not exist.");
            return;
        }
        Debug.Log($"Playing sound {name}");
        s.source.Play();
    }

    public float GetSoundLength()
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Tried to play sound {s}, which does not exist.");
            return 0;
        }
        return s.source.clip.length;
    }

    private void Start()
    {
        
    }
}
