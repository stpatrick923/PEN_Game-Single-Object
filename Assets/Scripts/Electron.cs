using UnityEngine;
using System.Collections;

public class Electron : Ball {

	private GameObject toOrbit;
	private bool hasObjectToOrbit = false;
	private int axisValue;
	private Vector3 axis;
	private float rotateVelocity = 100.0f;
	private int orbitDistance;
	
	// Use this for initialization
	void Start () {
		orbitDistance = Random.Range (1, 5);
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if (hasObjectToOrbit) 
		{
			doSomeOrbiting();
		}
	}

	//follow the creator cube, but orbit the object it collided with
	void OnCollisionEnter(Collision collision)
	{
		toOrbit = collision.gameObject;
		if (toOrbit.transform.parent != null || toOrbit.tag == "Creator Cube") 
		{
			GameObject parentObject = GameObject.FindGameObjectWithTag("Creator Cube");
			gameObject.transform.parent = parentObject.transform;
		}
		hasObjectToOrbit = true;
	}
	
	void doSomeOrbiting()
	{
		transform.RotateAround (toOrbit.transform.position, Vector3.up, rotateVelocity * Time.deltaTime);
		transform.position = toOrbit.transform.position + (transform.position - toOrbit.transform.position).normalized * orbitDistance;
	}
}
