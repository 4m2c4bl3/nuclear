using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {
    public GameObject spawnPoint;
    public static startGame startG;

	void Start () {

        startG = this;
        playerStats.Player.resetLife(3);
        spawnPoint.GetComponent<playerMove>().isActive = true;
    	}
	
}
