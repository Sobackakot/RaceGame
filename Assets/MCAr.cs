using UnityEngine;

public class MCAr : MonoBehaviour
{
    public float speedForce = 1500f;
    public float turnAngle = 45f;
    public float brake = 2000f;


    public Transform trLeftFron;
    public Transform trRightFron;
    public Transform trLeftBack;
    public Transform trRightBack;

    public WheelCollider collLeftFron;
    public WheelCollider collRightFron;
    public WheelCollider collLeftBack;
    public WheelCollider collRightBack;
      
    public void Update()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");


        
        collLeftBack.motorTorque = z  * speedForce;
        collRightBack.motorTorque = z * speedForce;

        collLeftFron.steerAngle = x * turnAngle;
        collRightFron.steerAngle = x * turnAngle;


        if (Input.GetKey(KeyCode.Space))
        {
            collLeftBack.brakeTorque = brake;
            collRightBack.brakeTorque = brake;
        }
        else
        {
            collLeftBack.brakeTorque = 0;
            collRightBack.brakeTorque = 0;
        }

        UpdateTransform(trLeftFron, collLeftFron);
        UpdateTransform(trRightFron, collRightFron);
        UpdateTransform(trLeftBack, collLeftBack);
        UpdateTransform(trRightBack, collRightBack);
    }
    public void UpdateTransform(Transform trans, WheelCollider coll)
    {
        coll.GetWorldPose(out Vector3 pos, out Quaternion rot);
        trans.position = pos;
        trans.rotation = rot; 
    }
}
