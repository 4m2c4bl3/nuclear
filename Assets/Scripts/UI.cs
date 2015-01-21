using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    public Texture2D lifecounter;

	void onGUI () {

        if (playerStats.Player.Lives == 3)
        {
            GUI.Label(new Rect((Screen.width / 2) - 55, 0, 55, 55), lifecounter);
            GUI.Label(new Rect((Screen.width / 2), 0, 55, 55), lifecounter);
            GUI.Label(new Rect((Screen.width / 2) + 55, 0, 55, 55), lifecounter);
        }

        if (playerStats.Player.Lives == 2)
        {
            GUI.Label(new Rect((Screen.width / 2) - 55, 0, 55, 55), lifecounter);
            GUI.Label(new Rect((Screen.width / 2), 0, 55, 55), lifecounter);
        }

        if (playerStats.Player.Lives == 1)
        {
            GUI.Label(new Rect((Screen.width / 2) - 55, 0, 55, 55), lifecounter);
        }
	
	}
}
