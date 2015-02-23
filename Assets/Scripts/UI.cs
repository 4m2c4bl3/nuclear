﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class UI : MonoBehaviour {
    //User Interfaaace. :3c
    //Changes depending on what scene is up via sceneManager
    public Color lives = new Color32(59, 255, 0, 255);
    public Color totalLives = new Color32(239, 0, 112, 255);
    public Texture2D lifecounter;
    float lifeBar;
    bool _menuOpen;
    bool displayMenu;
    public GUISkin menuSkin;
    string[] pauseMenu = new string[3] 
        {
            "Resume", "Main Menu", "Quit"
        };
    string[] mainMenu = new string[2] 
        {
            "New Game", "Quit"
        };

    bool menuOpen
    {
        get
        {
            return _menuOpen;
        }

        set
        {
            if (!_menuOpen && value)
            {
                Time.timeScale = 0;
                playerStats.Player.menuOpen = true;
                displayMenu = true;
            }

            _menuOpen = value;
        }
    }
    
    void OnGUI()
    {
        if (sceneManager.manager.curScene == sceneManager.allScenes.Level)
        {
        GUI.color = lives;
        drawTokens(lifecounter, playerStats.Player.Lives, 0);

        GUI.color = totalLives;
        drawTokens(lifecounter, playerStats.Player.totalLives, lifecounter.height + 5);

            if (displayMenu)
        {
            GUI.skin = menuSkin;
            GUI.BeginGroup(new Rect((Screen.width / 4), (Screen.height / 4), ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)));
            GUI.Box(new Rect(0, 0, ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)), "Menu");
            if (GUI.Button(new Rect(0, 25,( Screen.width * 0.5f), 50), pauseMenu[0]))
            {
                Time.timeScale = 1;
                playerStats.Player.menuOpen = false;
                displayMenu = false;

            }
            if (GUI.Button(new Rect(0, 80, (Screen.width * 0.5f), 50), pauseMenu[1]))
            {
                soundManager.m.Play(0);
                playerStats.Player.menuOpen = false;
                Application.LoadLevel(0);

            }
            if (GUI.Button(new Rect(0, 135, (Screen.width * 0.5f), 50), pauseMenu[2]))
            {

                soundManager.m.Play(0);
                Application.Quit();
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
            }

            GUI.EndGroup();
        }

        }
        if (sceneManager.manager.curScene == sceneManager.allScenes.Menu)
        {
            GUI.skin = menuSkin;
            GUI.BeginGroup(new Rect((Screen.width / 4), (Screen.height / 4), ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)));
            GUI.Box(new Rect(0, 0, ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)), "Reaktor");
            if (GUI.Button(new Rect(0, 80, (Screen.width * 0.5f), 50), mainMenu[0]))
            {
                soundManager.m.Play(0);
                Application.LoadLevel(1);

            }
            if (GUI.Button(new Rect(0, 135, (Screen.width * 0.5f), 50), mainMenu[1]))
            {

                soundManager.m.Play(0);
                Application.Quit();
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
            }

            GUI.EndGroup();
        }        
        if (sceneManager.manager.curScene == sceneManager.allScenes.GameOver)
        {
            if (playerStats.Player.Lost)
            {
                GUI.skin = menuSkin;
                GUI.BeginGroup(new Rect((Screen.width / 4), (Screen.height / 4), ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)));
                GUI.Box(new Rect(0, 0, ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)), "You Lost");
                if (GUI.Button(new Rect(0, 80, (Screen.width * 0.5f), 50), mainMenu[0]))
                {
                    soundManager.m.Play(0);
                    Application.LoadLevel(0);

                }
                if (GUI.Button(new Rect(0, 135, (Screen.width * 0.5f), 50), mainMenu[1]))
                {

                    soundManager.m.Play(0);
                    Application.Quit();
#if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
#endif
                }

                GUI.EndGroup();
            }
            else
            {
                GUI.skin = menuSkin;
                GUI.BeginGroup(new Rect((Screen.width / 4), (Screen.height / 4), ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)));
                GUI.Box(new Rect(0, 0, ((Screen.width / 4) * 2), ((Screen.height / 4) * 2)), "You Won!");
                if (GUI.Button(new Rect(0, 80, (Screen.width * 0.5f), 50), mainMenu[0]))
                {
                    soundManager.m.Play(0);
                    Application.LoadLevel(0);

                }
                if (GUI.Button(new Rect(0, 135, (Screen.width * 0.5f), 50), mainMenu[1]))
                {

                    soundManager.m.Play(0);
                    Application.Quit();
#if UNITY_EDITOR
                    EditorApplication.isPlaying = false;
#endif
                }

                GUI.EndGroup();
            }
        }
	}


    void drawTokens(Texture2D obj, float var, float topAlign)
    {
        if (var == 5)
        {
            GUI.Label(new Rect((Screen.width / 2) - (obj.width * 2), topAlign, obj.width, obj.height), obj);
            GUI.Label(new Rect((Screen.width / 2) - obj.width, topAlign, obj.width, obj.height), obj);
            GUI.Label(new Rect((Screen.width / 2), topAlign, obj.width, obj.height), obj);
            GUI.Label(new Rect((Screen.width / 2) + obj.width, topAlign, obj.width, obj.height), obj);
            GUI.Label(new Rect((Screen.width / 2) + (obj.width * 2), topAlign, obj.width, obj.height), obj);
        }
        if (var == 4)
         {
             GUI.Label(new Rect((Screen.width / 2) - (obj.width * 2), topAlign, obj.width, obj.height), obj);
             GUI.Label(new Rect((Screen.width / 2) - obj.width, topAlign, obj.width, obj.height), obj);
             GUI.Label(new Rect((Screen.width / 2), topAlign, obj.width, obj.height), obj);
             GUI.Label(new Rect((Screen.width / 2) + obj.width, topAlign, obj.width, obj.height), obj);
        }

        if (var == 3)
        {
            GUI.Label(new Rect((Screen.width / 2) - (obj.width * 2), topAlign, obj.width, obj.height), obj);
            GUI.Label(new Rect((Screen.width / 2) - obj.width, topAlign, obj.width, obj.height), obj);
            GUI.Label(new Rect((Screen.width / 2), topAlign, obj.width, obj.height), obj);
        }

        if (var == 2)
        {
            GUI.Label(new Rect((Screen.width / 2) - (obj.width * 2), topAlign, obj.width, obj.height), obj);
            GUI.Label(new Rect((Screen.width / 2) - obj.width, topAlign, obj.width, obj.height), obj);
        }

        if (var == 1)
        {
            GUI.Label(new Rect((Screen.width / 2) - (obj.width * 2), topAlign, obj.width, obj.height), obj);
        }
    }


    void Update()
    {
        //lifeBar = (lifecounter.width - (lifecounter.width - (playerStats.Player.Lives * lifecounter.height)));
        menuOpen = Input.GetKey(KeyCode.Escape);
        //Debug.Log(lifeBar);
    }
}
