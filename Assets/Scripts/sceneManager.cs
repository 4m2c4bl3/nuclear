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

	 public enum allScenes { None, Menu, Level1, GameOver}

    void Update ()
     {
        if (Application.loadedLevelName == "demoscene_1")
        {
            curScene = allScenes.Level1;
        }
     }


	}
