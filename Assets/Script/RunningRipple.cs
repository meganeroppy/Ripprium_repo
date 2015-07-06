using UnityEngine;
using System.Collections;

public class RunningRipple : MonoBehaviour {
	
	//[SerializeField]
	//private Ripple ripple;
	
	[SerializeField]
	float speed = 10f;
	
	[SerializeField]
	private GameObject ripplePrefab;
	private Ripple rippleR;
	private Ripple rippleL;
	
	private float effectTendency = 0.1f;
	private float timer = 0;
	
	private CharacterController controller;
	//private FPSInputController inputController;
	
	private Vector3 offset = new Vector3(1.5f, 0.0f, 0.0f);
	private bool effectOnRight = true;
	
	private int MaxRipple = 25;
	private int rippleCount = 0;
	
	void Awake(){

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
	
	
		this.transform.Translate (0,0, speed * Time.deltaTime );
		
		if(timer > effectTendency){
			//			Debug.Log("Create");
			timer = 0;
			//	UpdateEffectPos();
			if(effectOnRight){
				CreateRipple(true);
				}else{
				CreateRipple(false);
							}
			effectOnRight = !effectOnRight;
			
			if(rippleCount > MaxRipple){
				Destroy(this.gameObject, 2);
			}else{
				rippleCount++;
			}
			
		}else{
			timer += Time.deltaTime;
		}
		
	}
	
	private void CreateRipple(bool right){
		Ripple	ripple = Instantiate(ripplePrefab).GetComponent<Ripple>();
		ripple.transform.SetParent(this.transform);
		ripple.transform.localPosition = new Vector3( offset.x * (right ? 1 : -1), 0.00f, offset.z);
		ripple.Create(true);
	}
	
	private void UpdateEffectPos(){
		
		//	ripple.transform.SetParent(this.transform);
		
		//	Vector3 myPos = this.transform.position;
		//	Vector3 newPos = new Vector3(myPos.x + (offset.x * (effectOnRight ? 1 : -1) ), 0.01f, myPos.z + offset.z);
		Vector3 newPos = new Vector3( (offset.x * (effectOnRight ? 1 : -1) ), -1.0f, offset.z);
		//Vector3 newPos = Vector3.zero;
		
		//	ripple.transform.localPosition = newPos;
		//	effectOnRight = !effectOnRight;
	}
}
