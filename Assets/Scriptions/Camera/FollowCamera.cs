using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 offset;
    public Transform carTransform;
    public float speed = 10f;

    public void Start()
    {
        offset = transform.position - carTransform.position; // получаем растояние между А и Б
    }
    private void FixedUpdate()
    {   
        //движение камеры за целью 
        Vector3 targetPoint = carTransform.TransformPoint(offset);// получаем точку положения машины в качестве цели для камеры
        transform.position = Vector3.Lerp(transform.position, targetPoint, speed * Time.deltaTime); // плавное смещение от позиции А к позиции Б

        //поворот камеры за целью 

        Vector3 newDirection = carTransform.position - transform.position; // получаем направление камеры 
        Quaternion targetAxisRotate = Quaternion.LookRotation(newDirection, Vector3.up); // говорим посмотри и повернись в направлении  и по оси
        transform.rotation = Quaternion.Lerp(transform.rotation, targetAxisRotate, speed * Time.deltaTime); // плавно поворачиваем камеру
    }
}
