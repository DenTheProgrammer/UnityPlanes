using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float forwardAccelaration = 1;
    [SerializeField] float maxSpeed = 10;
    float inputVertical;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        float rotationAngle = -inputVertical * rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAngle));
        

        rb.velocity += transform.right * forwardAccelaration * Time.deltaTime;
        if (rb.velocity.sqrMagnitude > Mathf.Pow(maxSpeed, 2))
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
