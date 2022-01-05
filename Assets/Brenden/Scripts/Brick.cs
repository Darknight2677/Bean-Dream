using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.isKinematic = true;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log(col.gameObject.name);
		if (col.gameObject.name.Equals ("Player")) {
			Invoke ("DropPlatform", 0.5f);
			Destroy (gameObject, 2f);
		}
	}

	void DropPlatform()
	{
		rb.isKinematic = false;
	}
}
