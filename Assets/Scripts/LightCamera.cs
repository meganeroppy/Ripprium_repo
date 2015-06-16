using UnityEngine;
using System.Collections;

public class LightCamera : MonoBehaviour {

	[SerializeField]
	private Transform playerCamera;
	private Vector3 offset;
	private Vector3 playerOrigin;
	
	private void Awake(){
		offset = this.transform.position - playerCamera.transform.position;
		playerOrigin = playerCamera.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(playerCamera != null){
			//this.transform.position = playerCamera.position + offset;

			Vector3 playerDiffs = playerCamera.transform.position - playerOrigin;
			Debug.Log(playerDiffs);
			Vector3 myDiffs = playerDiffs * 0.333f;

			this.transform.position = myDiffs + offset;
			//Vector3 newPos = new Vector3 (playerCamera.transform.parent.transform.position.x / 3, playerCamera.transform.parent.transform.position.y, playerCamera.transform.parent.transform.position.z / 3) + offset;
			//this.transform.position = newPos;
			this.transform.rotation = playerCamera.rotation;
		}
	}
}
