using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    //User Interfaaace. :3c
    //Changes depending on what scene is up via sceneManager
    public Color lives;
    public Texture2D lifecounter;
    
    void OnGUI()
    {
        if (sceneManager.manager.curScene == sceneManager.allScenes.Level1)
        {
        GUI.color = lives;

        if (playerStats.Player.Lives == 3)
        {
            GUI.Label(new Rect((Screen.width / 2) - 30, 0, 30, 30), lifecounter);
             GUI.Label(new Rect((Screen.width / 2), 0, 30, 30), lifecounter);
             GUI.Label(new Rect((Screen.width / 2) + 30, 0, 30, 30), lifecounter);
        }

        if (playerStats.Player.Lives == 2)
        {
            GUI.Label(new Rect((Screen.width / 2) - 30, 0, 30, 30), lifecounter);
            GUI.Label(new Rect((Screen.width / 2), 0, 30, 30), lifecounter);
        }

        if (playerStats.Player.Lives == 1)
        {
            GUI.Label(new Rect((Screen.width / 2) - 30, 0, 30, 30), lifecounter);
        }
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
}
