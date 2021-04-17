using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(0f,1f)]
    [SerializeField] float lerpT = 0.1f;
    [SerializeField] float lookForwardDistance = 0f;
    [SerializeField] Rigidbody planeRB;
    Vector3 camOffset;

    void Start()
    {
        camOffset = transform.position - planeRB.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 planePosition = planeRB.transform.position;
        //Vector3 planeSpeedDirection = planeRB.velocity.normalized;
        Vector3 planeDirection = planeRB.transform.right;
        Vector3 desiredPosition = planePosition + camOffset + (lookForwardDistance * planeDirection);

        
        transform.position = Vector3.Lerp(transform.position, desiredPosition, lerpT);
    }
}
