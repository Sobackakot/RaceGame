using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    void Start()
    {
        offset = transform.position  - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + target.position;  
        transform.rotation = target.rotation;
    }
}
