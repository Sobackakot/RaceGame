using System.Collections.Generic;
using UnityEngine;

public class WheelsMyCar : MonoBehaviour
{    
    public List<WheelsData> wheelsData;
    private Vector3 axisInput;

    public float moveFOrce = 2000f;
    public float stopForce = 1500f;
    public float maxAngleWheel = 60f;

    private void LateUpdate()
    {
        axisInput = InputKey();

        // инициализируем каждое колесо трансформ и колайдер, передаем каждый трансформ и колайдер колеса все 4 клолеса 
        foreach (WheelsData wheel in wheelsData)
        {
            UpdateTransformWheels(wheel.wheelTransform, wheel.wheelCollider);
        }
    }
    private void FixedUpdate()
    {
        MoveCar(axisInput);
        StopCar();
        TurnsCar(axisInput);
    }
       
    private Vector3 InputKey()
    {
        // получаем напвравлени€ движени€ при нажатии на кнопки W,A,S,D
        float vertical = Input.GetAxis("Vertical"); // key down - W,A  = float от -1f  до 1f
        float horizontal = Input.GetAxis("Horizontal");// key down - S,D  = float от -1f  до 1f
        return new Vector3(horizontal, 0, vertical);
    }
    
    private void TurnsCar(Vector3 axis)
    {
        // поворот колес 
        foreach (WheelsData wheel in wheelsData)
        {
            switch (wheel.wheelType)
            {
                case WheelType.LeftFront:
                case WheelType.RightFront:
                    wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, maxAngleWheel * axis.x, 0.5f);
                    break;

            }
        }
    }

    private void StopCar()
    {
        // торможение
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (WheelsData wheel in wheelsData)
            {
                wheel.wheelCollider.brakeTorque = stopForce;
            }
        }
    }

    private void MoveCar(Vector3 axis)
    {
        // движкение вперед и назад
        foreach (WheelsData wheel in wheelsData)
        {
            wheel.wheelCollider.motorTorque = axis.z * moveFOrce;
        }
    } 
    private void UpdateTransformWheels(Transform transform, WheelCollider collider)
    {
        collider.GetWorldPose(out Vector3 pos, out Quaternion rot); // вызываем функцию GetWorldPose
        // котора€ имеет 2 аргумента с опператором out - это говорит нам о том что мы можем передать ему пустые локальные переменные
        // которые он проинициализируем сам, в резуальтате мы получим позицию и вращение 
        transform.position = pos; // инициализируем каждое колесо его позицию 
        transform.rotation = rot; // инициализируем каждое колесо его поворот 
    }
}
