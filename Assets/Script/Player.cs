﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//[SerializeField]
	//private Ripple ripple;
	
	[SerializeField]
	private GameObject ripplePrefab;
	private Ripple rippleR;
	private Ripple rippleL;
	[SerializeField]
	private RunningRipple runningRipple;

	private float effectTendency = 0.5f;
	private float timer = 0;

	private CharacterController controller;
	private FPSInputController inputController;

	private Vector3 offset = new Vector3(1.5f, 0.0f, 0.0f);
	private bool effectOnRight = true;

	private Transform myCamera;
	private Transform cameraObject;

	void Awake(){
		if (UnityEditor.PlayerSettings.virtualRealitySupported) {
			myCamera = this.transform.GetChild (0);
			myCamera.localRotation = Quaternion.identity;
			cameraObject = GameObject.Find("CameraObject").transform;
			myCamera.SetParent (cameraObject);
			myCamera.transform.localPosition = new Vector3 (0, 1.2f, 0);
		}
		controller = GetComponent<CharacterController>();
		inputController = GetComponent<FPSInputController>();
	}

	// Use this for initialization
	void Start () {

		rippleR = Instantiate(ripplePrefab).GetComponent<Ripple>();
		rippleR.transform.SetParent(this.transform);
		rippleR.transform.localPosition = new Vector3( offset.x, 0.00f, offset.z);

		rippleL = Instantiate(ripplePrefab).GetComponent<Ripple>();
		rippleL.transform.SetParent(this.transform);
		rippleL.transform.localPosition = new Vector3( -offset.x, 0.00f, offset.z);

	}
	
	// Update is called once per frame
	void Update () {
		if (UnityEditor.PlayerSettings.virtualRealitySupported) {
		//	myCamera.localRotation = Quaternion.identity;

			Vector3 playerCamRot = myCamera.rotation.eulerAngles;
			Vector3 newRot = new Vector3(this.transform.rotation.x, playerCamRot.y, this.transform.rotation.z);
			this.transform.rotation = Quaternion.Euler( newRot );
//			Debug.Log (this.transform.rotation.eulerAngles + " / " + myCamera.rotation.eulerAngles);
			//Debug.Log (this.transform.localRotation.eulerAngles + " / " + myCamera.localRotation.eulerAngles);
		}

		if(Goal.completed){
			if(controller.enabled == true){
				controller.enabled = false;
			}

			if(GetComponent<CharacterMotor>().enabled == true){
				GetComponent<CharacterMotor>().enabled = false;
			}
		}
		
	
		if(inputController){
			return;
		}


		rippleR.gameObject.SetActive(controller.isGrounded);
		rippleL.gameObject.SetActive(controller.isGrounded);

		if(timer > effectTendency){
//			Debug.Log("Create");
			timer = 0;
			//	UpdateEffectPos();
			if(effectOnRight){
				rippleR.Create();
			}else{
				rippleL.Create();
			}
			effectOnRight = !effectOnRight;

		}else{
			timer += Time.deltaTime;
		}
	}
		
	private void UpdateEffectPos(){

	//	ripple.transform.SetParent(this.transform);

	//	Vector3 myPos = this.transform.position;
	//	Vector3 newPos = new Vector3(myPos.x + (offset.x * (effectOnRight ? 1 : -1) ), 0.01f, myPos.z + offset.z);
		Vector3 newPos = new Vector3( (offset.x * (effectOnRight ? 1 : -1) ), 0.05f, offset.z);
		//Vector3 newPos = Vector3.zero;

	//	ripple.transform.localPosition = newPos;
	//	effectOnRight = !effectOnRight;
	}
	
	public void CreateRunningRipple(){
	Vector3 pos = this.transform.position;
		Instantiate( runningRipple , new Vector3(pos.x, 0, pos.z), this.transform.rotation);
	}
}


