using UnityEngine;
using System.Collections;

public class sceneManager : MonoBehaviour {
    [HideInInspector]
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
         if (Application.loadedLevel == 0)
         {
             curScene = allScenes.Menu;
         }
        if (Application.loadedLevel == 1)
        {
            curScene = allScenes.Level;
        }
        if (Application.loadedLevel == 2)
        {
            curScene = allScenes.Menu;
        }
        Debug.Log(Application.loadedLevel);
     }


	}
