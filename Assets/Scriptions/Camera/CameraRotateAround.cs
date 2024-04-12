using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limit = 80; // ограничение вращения по vertical
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	private float horizontal, vertical;


	void Update ()
	{
		if(Input.GetAxis("Mouse ScrollWheel") > 0) 
			offset.z += zoom;
		else if(Input.GetAxis("Mouse ScrollWheel") < 0) 
			offset.z -= zoom;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		horizontal += Input.GetAxis("Mouse horizontal") * sensitivity;
		vertical += Input.GetAxis("Mouse vertical") * sensitivity;
		vertical = Mathf.Clamp (vertical, -limit, limit);
		transform.localEulerAngles = new Vector3(-vertical, horizontal, 0);
		transform.position = transform.localRotation * offset + target.position;
	}
}