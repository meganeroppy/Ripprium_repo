using UnityEngine;
using System.Collections;

public class LightCamera : MonoBehaviour {

	[SerializeField]
	private Transform playerCamera;
	private Vector3 diff;
	private Vector3 playerOrigin;
	private Vector3 playerOffset;
	private Vector3 myOrigin;
	private Vector3 myOffset;
	
	private void Awake(){
		diff = this.transform.position - playerCamera.transform.position;
		playerOrigin = playerCamera.transform.position;
		myOrigin = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(playerCamera != null){
			//this.transform.position = playerCamera.position + diff;
			
			playerOffset = playerCamera.position - playerOrigin;
			myOffset = new Vector3(playerOffset.x * 0.1f, playerOffset.y * 0.1f, playerOffset.z * 0.1f);
			Vector3 newPos = myOrigin + myOffset;
			
			this.transform.position = newPos;
			
//			Vector3 playerDiffs = playerCamera.transform.position - playerOrigin;
			//Debug.Log("newPos :" + newPos + " / playerCamera.position :" + playerCamera.position );
//			Vector3 myDiffs = playerDiffs * 0.333f;

//			this.transform.position = myDiffs + diff;
			//Vector3 newPos = new Vector3 (playerCamera.transform.parent.transform.position.x / 3, playerCamera.transform.parent.transform.position.y, playerCamera.transform.parent.transform.position.z / 3) + diff;
			//this.transform.position = newPos;

			this.transform.rotation = playerCamera.rotation;
		}
	}
}
