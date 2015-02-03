using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {

    public Transform target;
    public float smooth = 5.0f;

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Active").transform;
        Vector3 targetView = new Vector3(target.position.x, target.position.y, target.position.z - 10);
           transform.position = Vector3.Lerp(
            transform.position, targetView,
            Time.deltaTime * smooth);
    } 
}
