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
        delay.setTimer(2);
    }

    public void reSpawn()
    {
        startGame.startG.spawnPoint.GetComponent<playerMove>().isActive = true;
        playerStats.Player.resetLife(3);
        delay.setTimer(2);

        if (startGame.startG.spawnPoint != this)
        {
            isActive = false;
        }
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
                    leftTarget.GetComponent<playerMove>().isActive = true;
                    isActive = false;
                    delay.setTimer(0.5f);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) && rightTarget != null)
                {
                    rightTarget.GetComponent<playerMove>().isActive = true;
                    isActive = false;
                    delay.setTimer(0.5f);
                }

                if (Input.GetKeyDown(KeyCode.UpArrow) && upTarget != null)
                {
                    upTarget.GetComponent<playerMove>().isActive = true;
                    isActive = false;
                    delay.setTimer(0.5f);
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) && downTarget != null)
                {
                    downTarget.GetComponent<playerMove>().isActive = true;
                    isActive = false;
                    delay.setTimer(0.5f);
                }
            }
            

           
        }      
	
	}
}
