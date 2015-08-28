using UnityEngine;
using System.Collections;

public class Neutron : Ball {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (gameObject.transform.parent == null) 
		{
			GameObject otherObject = collision.gameObject;
			if (isControlledObject(otherObject))
			{
				GameObject creatorCube = GameObject.FindGameObjectWithTag("Creator Cube");
				gameObject.transform.SetParent (creatorCube.transform);
				Rigidbody rb = gameObject.GetComponent<Rigidbody>();
				rb.isKinematic = true;
			}
		}
		
	}
	
	bool isControlledObject(GameObject thing)
	{
		if (thing.transform.parent != null)
			return true;
		else if (thing.tag == "Creator Cube")
			return true;
		else
			return false;
	}
	
	
}
