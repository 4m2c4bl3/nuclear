using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {
    //Runs each time a new game begins. Specifies the spawn point that is used for respawn & resets the players lives. Can be used for other quick cleanup.
    //Makes sure there's a working statsAndDisplay object (sceneManager & playerStats & UI) <- ONLY PLACE ONE OF THESE IN THE /MAIN MENU/ SCENE TO AVOID HAVING MULTIPLES RUNNNG.
    //NONE IN ANY OTHER SCENE OR THERE WILL BE CONFLICTS. IT TRANSFERS BETWEEN SCENES SO ITS ALL COOL.
    [HideInInspector]
    public GameObject spawnPoint;
    public GameObject sad;
    public static startGame startG;

    void Awake ()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
                GameObject statsAndDisplay = Instantiate(sad.gameObject, transform.position, transform.rotation) as GameObject;
        }
        startG = this;
    }
	void Start ()
    {
        playerStats.Player.lastMove = playerStats.moveDir.None;
        playerStats.Player.resetLife();
        playerStats.Player.totalLives = 5;
        playerStats.Player.spawnPoint = spawnPoint;
        soundManager.m.Play(1);
        camMove.cam.resetPlz = true;
    }

    
}
