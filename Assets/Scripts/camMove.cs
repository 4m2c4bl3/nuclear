using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {

    Transform basePos;
    public Transform target;
    public float smooth = 5.0f;
    public float camSpeed = 0.3f;
    public bool targetSet = false;
    public Color camStart = new Color32(239, 0, 112, 255);
    public Color camEnd = new Color32(0, 0, 0, 255);
    public Color moveLeft = new Color32(84, 255, 253, 255);
    public Color moveRight = new Color32(250, 255, 15, 255);
    public Color moveUp = new Color32(219, 136, 39, 255);
    public Color moveDown = new Color32(132, 41, 144, 255);
    public bool isManual = false;
    Vector3 targetView;
    Timer time = new Timer();
    bool start;
    public float camdist = -15;
    public static camMove cam;
        
    void Start ()
    {
        transform.position = new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y, camdist);
        cam = this;
    }

    public void setCam()
    {
        target = GameObject.FindGameObjectWithTag("Active").transform;
        basePos = target;

        if (targetSet == false)
        { 
            targetSet = true; 
        }
        if (isManual == false)
        {
            //gameObject.transform.parent =          ohhh shitttttt :(
        }
        
    }

    void manualMove()
    {
         if (targetSet == false)
        {
            setCam();
        }
        target = GameObject.FindGameObjectWithTag("Active").transform;
        Vector3 targetView = new Vector3(target.position.x, basePos.position.y, target.position.z);
         transform.position = Vector3.Lerp(
          transform.position, targetView,
         Time.deltaTime * smooth);
    }

    void autoMove()
    {
        if (targetSet == false)
        {
            setCam();
        }
        if (gameObject.GetComponentInParent<camDirs>().forwardTarget != null)
        {
            gameObject.transform.parent = gameObject.GetComponentInParent<camDirs>().forwardTarget.transform;
            targetView = new Vector3(gameObject.GetComponentInParent<camDirs>().forwardTarget.transform.position.x, gameObject.GetComponentInParent<camDirs>().forwardTarget.transform.position.y, camdist);
            time.setTimer(camSpeed);
        }
    }

    void Update()
    {
        if (start == false)
        {
            time.setTimer(camSpeed);
            setCam();
            transform.position = new Vector3(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y, camdist);
            start = true;
        }

      if (isManual == true && start == true)
      {
          manualMove();
      }
      else if (isManual == false && start == true)
      {
          if (time.Ok() == true)
          {
              autoMove();
          } 
          transform.position = Vector3.Lerp(
           transform.position, targetView,
          Time.deltaTime * smooth);
      }
    } 
}
