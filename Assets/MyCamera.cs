using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		player = this.transform.parent.transform;
	//	this.transform.SetParent (null);

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localRotation = Quaternion.identity;
		this.transform.position = player.position;
	}
}
