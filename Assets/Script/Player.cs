using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//[SerializeField]
	//private Ripple ripple;
	
	[SerializeField]
	private GameObject ripplePrefab;
	private GameObject ripple;
	
	private float effectTendency = 0.15f;
	private float timer = 0;
	
	private CharacterController controller;
	private FPSInputController inputController;

	void Awake(){
		controller = GetComponent<CharacterController>();
		inputController = GetComponent<FPSInputController>();
	}

	// Use this for initialization
	void Start () {
		ripple = Instantiate(ripplePrefab, this.transform.position, this.transform.rotation) as GameObject;
		//Vector3 pos = ripple.transform.position;
		//ripple.transform.position = new Vector3(pos.x, 0.01f, pos.z);
		//ripple.transform.SetParent(this.transform);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(inputController.isStop){
			return;
		}
		UpdateEffectPos();
		
		ripple.SetActive(controller.isGrounded);
		
		
		if(timer > effectTendency){
			timer = 0;
			if(Random.Range(0, 3) == 0){
		//		MakeEffect();
			}
		}else{
			timer += Time.deltaTime;
		}
	
	}
	
	
	private void UpdateEffectPos(){
	/*
		RaycastHit[] raycastHits = Physics.RaycastAll(this.transform.position, Vector3.down, 2.1f);
		if(raycastHits.Length >= 1){
			return;
		}
	*/
		Vector3 pos = this.transform.position;
		ripple.transform.position = new Vector3(pos.x, 0.01f, pos.z);
	}
}
