
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
            WheelFrictionCurve forwardFriction = wheel.forwardFriction;
            forwardFriction.stiffness = hit.collider.material.staticFriction;
            wheel.forwardFriction = forwardFriction;

            WheelFrictionCurve sidewaysFriction = wheel.sidewaysFriction;
            sidewaysFriction.stiffness = hit.collider.material.staticFriction;
            wheel.sidewaysFriction = sidewaysFriction; 
        }
    }
}
