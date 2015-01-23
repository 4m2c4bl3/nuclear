using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    //User Interfaaace. :3c
    //For all scenes, what it displays depends on the name of the object it's attached to.
    public Color lives;
    public Texture2D lifecounter;
    
    void OnGUI()
    {
        if (gameObject.name == "playerAll")
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
        if (gameObject.name == "mainMenu")
        {
            //draw main menu buttons
        }
        if (gameObject.name == "gameOverMenu")
        {
            //draw game over buttons
        }
	}
}
