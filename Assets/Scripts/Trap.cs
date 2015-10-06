using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	[SerializeField]
	private GameObject[] moveTargets;
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
	
		Debug.Log("ExecuteTrap!");
		int num = moveTargets.Length;
		for(int i = 0 ; i < num ; i++){
			moveTargets[i].GetComponent<BlockingIdol>().Blocking();
		}
	}
}
