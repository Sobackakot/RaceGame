using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform car;
    public float speed = 10f;

    public void Start()
    {
        offset = transform.position - car.position;
    }
    private void FixedUpdate()
    {   
        Vector3 targetPoint = car.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPoint, speed * Time.deltaTime);

        Vector3 newDirection = car.position - transform.position;
        Quaternion newAngle = Quaternion.LookRotation(newDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, newAngle, speed * Time.deltaTime);
    }
}
