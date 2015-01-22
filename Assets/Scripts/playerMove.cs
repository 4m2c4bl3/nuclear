using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
    //The "player movement" script. Says if the player is "on" this object or not, and moves the player around to other objects. Handles respawn move as well.
    public GameObject upTarget;
    public GameObject downTarget;
    public GameObject leftTarget;
    public GameObject rightTarget;
    public bool _isActive;
    Timer delay = new Timer();
    public float respawnPause = 2f;
    public float movePause = 0.5f;

    public bool isActive
    {
        get
        {
            return _isActive;
        }

        set 
        {
            (gameObject.GetComponent("Halo") as Behaviour).enabled = value;

            _isActive = value;
        }
    }
    
    void Start()
    {
        delay.setTimer(respawnPause);
    }

    public void reSpawn()
    {
        delay.setTimer(respawnPause); 
        startGame.startG.spawnPoint.GetComponent<playerMove>().isActive = true;
        playerStats.Player.resetLife();        

        if (startGame.startG.spawnPoint != this)
        {
            isActive = false;
        }
    }

    void moveTo(GameObject target)
    {
        delay.setTimer(movePause);  
        isActive = false;         
        target.GetComponent<playerMove>().isActive = true;              
    }

	void Update () {
        if (isActive)
        {
            if (playerStats.Player.Lives <= 0)
            {
                reSpawn();
            }

            if (delay.Ok() == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) && leftTarget != null)
                {
                    moveTo(leftTarget);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) && rightTarget != null)
                {
                    moveTo(rightTarget);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && upTarget != null)
                {
                    moveTo(upTarget);                    
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && downTarget != null)
                {
                    moveTo(downTarget);
                }
            }                       
        }      
	
	}
}
