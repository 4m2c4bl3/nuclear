using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    //User Interfaaace. :3c
    //Changes depending on what scene is up via sceneManager
    public Color lives = new Color32(59, 255, 0, 255);
    public Texture2D lifecounter;
    float lifeBar;
    
    void OnGUI()
    {
        if (sceneManager.manager.curScene == sceneManager.allScenes.Level)
        {
        GUI.color = lives;

        GUI.BeginGroup(new Rect((Screen.width / 2) - 120, 0, lifeBar, 30));
        GUI.Label(new Rect(0, 0, 296, 30), lifecounter);
        GUI.EndGroup();

        }
        if (sceneManager.manager.curScene == sceneManager.allScenes.Menu)
        {
            //draw main menu buttons
        }
        if (sceneManager.manager.curScene == sceneManager.allScenes.GameOver)
        {
            //draw game over buttons
        }
	}

    void Update()
    {
        lifeBar = ((playerStats.Player.Lives / playerStats.Player.maxLives) * 296);
        Debug.Log(lifeBar);
        Debug.Log(playerStats.Player.Lives);
        Debug.Log(playerStats.Player.maxLives);
    }
}
