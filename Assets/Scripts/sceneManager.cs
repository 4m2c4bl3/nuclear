using UnityEngine;
using System.Collections;

public class sceneManager : MonoBehaviour {

    public allScenes curScene = allScenes.None;
    public static sceneManager manager;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        manager = this;
    }

	 public enum allScenes { None, Menu, Level, GameOver}

    void Update ()
     {
        if (Application.loadedLevelName == "demo_scene")
        {
            curScene = allScenes.Level;
        }
     }


	}
