using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDayTime : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime, 0, 0));
    }
}
