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
        if (Application.loadedLevelName == "demoscene_1")
        {
            curScene = allScenes.Level;
        }
        if (Application.loadedLevelName == "working_demo_scene_1")
        {
            curScene = allScenes.Level;
        }
     }


	}
