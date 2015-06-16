using UnityEngine;
using System.Collections;

public class LightCamera : MonoBehaviour {

	[SerializeField]
	private Transform playerCamera;
	private Vector3 offset;
	
	private void Awake(){
	offset = this.transform.position - playerCamera.transform.position;
	}
	
	
	// Update is called once per frame
	void Update () {
		if(playerCamera != null){
			this.transform.position = playerCamera.position + offset;
			
				this.transform.rotation = playerCamera.rotation;
		}
	}
}
