using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

    public GameObject upTarget;
    public GameObject downTarget;
    public GameObject leftTarget;
    public GameObject rightTarget;
    public bool _isActive;

    bool isActive
    {
        get
        {
            return _isActive;
        }

        set 
        {
            if (_isActive != value)
            {
                if (!_isActive)
                {
                    (gameObject.GetComponent("Halo") as Behaviour).enabled = true;
                }
                if (_isActive)
                {
                    (gameObject.GetComponent("Halo") as Behaviour).enabled = false;
                }
            }          

            _isActive = value;
        }
    }
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && leftTarget != null)
            {
                leftTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && rightTarget != null)
            {
                rightTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && upTarget != null)
            {
                upTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && downTarget != null)
            {
                downTarget.GetComponent<playerMove>().isActive = true;
                isActive = false;
            }
        }      
	
	}
}
