using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

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

            if (Input.GetKeyDown(KeyCode.LeftArrow) && leftTarget != null && delay.Ok() == true)
            {
                delay.setTimer(0.5f);
                leftTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && rightTarget != null && delay.Ok() == true)
            {
                delay.setTimer(0.5f);
                rightTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && upTarget != null && delay.Ok() == true)
            {
                delay.setTimer(0.5f);
                upTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && downTarget != null && delay.Ok() == true)
            {
                delay.setTimer(0.5f);
                downTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;                
            }
        }      
	
	}
}
