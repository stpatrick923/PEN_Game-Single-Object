using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	private int power = 0;

	// Use this for initialization
	void Start () {
		//higher number = more likely to remove more stuff
		power = 7;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		GameObject collidedWith = collision.gameObject;
		if (collidedWith.transform.parent != null || collidedWith.tag == "Creator Cube") 
		{
			GameObject cube = GameObject.FindGameObjectWithTag("Creator Cube");

			//stayCheck: if it's greater than the bomb's power, the object stays attached.
			int stayCheck = 0;
			foreach (Transform child in cube.transform)
			{
				stayCheck = Random.Range (0, 10);
				if (stayCheck < power)
				{
					child.parent = null;
					child.GetComponent <Rigidbody>().isKinematic = true;
				}
			}

			Destroy (this);
		}
	}
}
