using UnityEngine;
using System.Collections;

public class RunningRipple : MonoBehaviour {
	
	//[SerializeField]
	//private Ripple ripple;
	
	[SerializeField]
	private GameObject ripplePrefab;
	private Ripple_particle rippleR;
	private Ripple_particle rippleL;
	
	private float effectTendency = 0.5f;
	private float timer = 0;
	
	private CharacterController controller;
	//private FPSInputController inputController;
	
	private Vector3 offset = new Vector3(1.5f, 0.0f, 0.0f);
	private bool effectOnRight = true;
	
	void Awake(){

	}
	
	// Use this for initialization
	void Start () {
		
		rippleR = Instantiate(ripplePrefab).GetComponent<Ripple_particle>();
		rippleR.transform.SetParent(this.transform);
		rippleR.transform.localPosition = new Vector3( offset.x, 0.00f, offset.z);
		
		rippleL = Instantiate(ripplePrefab).GetComponent<Ripple_particle>();
		rippleL.transform.SetParent(this.transform);
		rippleL.transform.localPosition = new Vector3( -offset.x, 0.00f, offset.z);
		
	}
	
	// Update is called once per frame
	void Update () {

		
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
		Vector3 newPos = new Vector3( (offset.x * (effectOnRight ? 1 : -1) ), 0.00f, offset.z);
		//Vector3 newPos = Vector3.zero;
		
		//	ripple.transform.localPosition = newPos;
		//	effectOnRight = !effectOnRight;
	}
}
