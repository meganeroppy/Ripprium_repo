using UnityEngine;
using System.Collections;

public class CameraObject : MonoBehaviour {

	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = player.position;
	}
}
