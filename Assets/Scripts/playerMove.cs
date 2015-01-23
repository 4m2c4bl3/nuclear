using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {
    //The "player movement" script. Says if the player is "on" this object or not, and moves the player around to other objects. 
    //Calls targetState effects to happen on move, handles targetState move effects.
    //Handles respawn move as well.
    public GameObject upTarget;
    public GameObject downTarget;
    public GameObject leftTarget;
    public GameObject rightTarget;
    public bool _isActive;
    bool pushing;
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
        target.GetComponent<targetState>().applyEffects();
    }

    public void doublePush()
    {
        if (pushing == false)
        {
        pushing = true;
        Debug.Log("..almost ready to push..");
        Debug.Log(playerStats.Player.lastMove);
        delay.setTimer(playerStats.Player.movePause);
        }
        
        if (pushing && delay.Ok() == true)
        {
            if (playerStats.Player.lastMove == playerStats.moveDir.Left && canMove(leftTarget) == true)
            {
                Debug.Log("..push!");
                moveTo(leftTarget);
                pushing = false;
            }
            if (playerStats.Player.lastMove == playerStats.moveDir.Right && canMove(rightTarget) == true)
            {
                Debug.Log("..push!");
                moveTo(rightTarget);
                pushing = false;
            }
            if (playerStats.Player.lastMove == playerStats.moveDir.Up && canMove(upTarget) == true)
            {
                Debug.Log("..push!");
                moveTo(upTarget);
                pushing = false;
            }
            if (playerStats.Player.lastMove == playerStats.moveDir.Down && canMove(downTarget) == true)
            {
                Debug.Log("..push!");
                moveTo(downTarget);
                pushing = false;
            }
        }
        
    }    

	void Update () {
        if (pushing)
        {
            doublePush();
        }
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
                    playerStats.Player.lastMove = playerStats.moveDir.Left;
                    moveTo(leftTarget);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) && canMove(rightTarget) == true)
                {
                    playerStats.Player.lastMove = playerStats.moveDir.Right;
                    moveTo(rightTarget);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && canMove(upTarget) == true)
                {
                    playerStats.Player.lastMove = playerStats.moveDir.Up; 
                    moveTo(upTarget);               
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && canMove(downTarget) == true)
                {
                    playerStats.Player.lastMove = playerStats.moveDir.Down;
                    moveTo(downTarget);
                }
            }                       
        }      
	
	}
}
