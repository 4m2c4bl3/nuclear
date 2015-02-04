using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {

    Transform basePos;
    public Transform target;
    public float smooth = 5.0f;
    bool targetSet = false;

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

    void Update()
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
}
