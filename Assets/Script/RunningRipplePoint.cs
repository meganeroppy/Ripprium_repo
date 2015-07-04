using UnityEngine;
using System.Collections;

public class RunningRipplePoint : MonoBehaviour {


private void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			col.gameObject.GetComponent<Player>().CreateRunningRipple();
		}
}	
	
}
