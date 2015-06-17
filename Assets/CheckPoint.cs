using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public bool isChecked {get; set;}

	// Use this for initialization
	void Awake () {
		this.isChecked = false;
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			this.isChecked = true;
			Debug.Log(this.gameObject.name + " has been checked");
		}
	}

}
