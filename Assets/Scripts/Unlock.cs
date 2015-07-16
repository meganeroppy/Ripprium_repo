using UnityEngine;
using System.Collections;

public class Unlock : MonoBehaviour {

	[SerializeField]
	private Door door;
	private bool done = false;
	

	private void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			ExecuteTrap();
		}
	}
	
	private void ExecuteTrap(){
		if(done){
			return;
		}
		done = true;
	
		Debug.Log("Open!");
		door.Open();
		
	}
}
