﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private bool beingDragged = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
	}

	bool isBeingDragged()
	{
		return beingDragged;
	}

	void setBeingDragged(bool currentlyBeingDragged)
	{
		beingDragged = currentlyBeingDragged;
	}
}
