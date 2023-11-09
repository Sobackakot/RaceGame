using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlane : MonoBehaviour
{
    private WheelCollider wheel;
    private void Start()
    {
        wheel = GetComponent<WheelCollider>();  
    }
    private void FixedUpdate()
    {
        WheelHit hit;
        if( wheel.GetGroundHit( out hit ))
        {
            WheelFrictionCurve fFriction = wheel.forwardFriction;
            fFriction.stiffness = hit.collider.material.staticFriction;
            wheel.forwardFriction = fFriction;

            WheelFrictionCurve sFriction = wheel.sidewaysFriction;
            sFriction.stiffness = hit.collider.material.staticFriction;
            wheel.sidewaysFriction = sFriction; 
        }
    }
}
