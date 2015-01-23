using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
    //The "player movement" script. Says if the player is "on" this object or not, and moves the player around to other objects. 
    //Calls targetState effects to happen on move.
    //Handles respawn move as well.
    public GameObject upTarget;
    public GameObject downTarget;
    public GameObject leftTarget;
    public GameObject rightTarget;
    public bool _isActive;
    Timer delay = new Timer();

    public bool isActive
    {
        get
        {
            return _isActive;
        }

        set
        {
            delay.setTimer(playerStats.Player.movePause); //SOLVED THE WEIRD JUMPING! AAHAAAAAA
            (gameObject.GetComponent("Halo") as Behaviour).enabled = value;
            if (value == true)
            {
                gameObject.GetComponent<targetState>().applyEffects();
            }
            _isActive = value;
        }
    }
    
    public bool canMove (GameObject target)
    {
        if (target != null && target.GetComponent<targetState>().Status != 1)
        {
             return true;
       
        }
            return false;
      

    }

    void Start()
    {
        delay.setTimer(playerStats.Player.respawnPause);
    }

    public void reSpawn()
    {
        delay.setTimer(playerStats.Player.respawnPause); 
        startGame.startG.spawnPoint.GetComponent<playerMove>().isActive = true;
        playerStats.Player.resetLife();        

        if (startGame.startG.spawnPoint != this)
        {
            isActive = false;
        }
    }

    public void moveTo(GameObject target)
    {
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
                if (Input.GetKeyDown(KeyCode.LeftArrow) && canMove(leftTarget) == true)
                {
                    moveTo(leftTarget);
                    playerStats.Player.lastMove = "left";
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) && canMove(rightTarget) == true)
                {
                    moveTo(rightTarget);
                    playerStats.Player.lastMove = "right";
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && canMove(upTarget) == true)
                {
                    moveTo(upTarget);
                    playerStats.Player.lastMove = "up";                   
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && canMove(downTarget) == true)
                {
                    moveTo(downTarget);
                    playerStats.Player.lastMove = "down";
                }
            }                       
        }      
	
	}
}
