using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {

    Transform basePos;
    public Transform target;
    public float smooth = 5.0f;
    bool targetSet = false;
    public Color camStart = new Color32(239, 0, 112, 255);
    public Color camEnd = new Color32(0, 0, 0, 255);
    public Color moveLeft = new Color32(84, 255, 253, 255);
    public Color moveRight = new Color32(250, 255, 15, 255);
    public Color moveUp = new Color32(219, 136, 39, 255);
    public Color moveDown = new Color32(132, 41, 144, 255);
    public bool isManual = false;

    void Start()
    {
        transform.position = new Vector3 (transform.position.x, target.position.y, target.position.z - 10);
    }
    
    void setCam()
    {
        target = GameObject.FindGameObjectWithTag("Active").transform;
        basePos = target;
        targetSet = true;

    }

    void manualMove()
    {
         if (targetSet == false)
        {
            setCam();
        }
        target = GameObject.FindGameObjectWithTag("Active").transform;
        Vector3 targetView = new Vector3(target.position.x, basePos.position.y, target.position.z - 10);
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
        }
    }

    void Update()
    {
      if (isManual == true)
      {
          manualMove();
      }
      else if (isManual == false)
      {
          autoMove();
      }
    } 
}
