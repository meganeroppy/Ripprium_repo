using UnityEngine;
using System.Collections;

public class RippleGenerator : MonoBehaviour {

	[SerializeField]
	private Ripple ripplePrefab;
	
	[SerializeField]
	private float tendency = 1;
	
	private float timer = 0;
		
	// Update is called once per frame
	void Update () {
		if(timer > tendency){
		timer = 0;
			MakeRipple();
		}else{
		timer += Time.deltaTime;
		}
	}
	
	private void MakeRipple(){
		Ripple ripple = Instantiate(ripplePrefab).GetComponent<Ripple>();
		ripple.transform.localPosition =this.transform.position;
		//ripple.transform.SetParent(this.transform);
	}
}
