using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {

    public AudioClip[] sounds;
    public AudioSource sfx;
    public AudioSource bgm;
    public static soundManager m;
    string lastLevel;

    void Awake()
    {
        m = this;
    }

    public void Play(int clip)
    {
        sfx.clip = sounds[clip];
        sfx.Play();
    }

    
    public void bgMusic()
    {
            if (sceneManager.manager.curScene == sceneManager.allScenes.Level)
            {
                bgm.clip = sounds[8];
                bgm.Play();
                lastLevel = Application.loadedLevelName;

            }

            if (sceneManager.manager.curScene == sceneManager.allScenes.GameOver)
            {
                if (playerStats.Player.Lost)
                {
                    bgm.clip = sounds[9];
                }
                else
                {
                    bgm.clip = sounds[10];
                }
                bgm.Play();
                lastLevel = Application.loadedLevelName;
        }        
    }

        void Update ()
        {
            if (Application.loadedLevelName != lastLevel)
            {
                bgMusic();
            }
        }        

    public void loopPlay(int clip, bool on)
    {
        if (on)
        {
            sfx.loop = true;
            sfx.clip = sounds[clip];
            sfx.Play();
        }

        if (!on)
        {
            sfx.loop = false;
        }
    }
}
