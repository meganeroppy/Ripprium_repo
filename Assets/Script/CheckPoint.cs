using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckPoint : MonoBehaviour {

	public bool isChecked {get; set;}

	[SerializeField]
	private GameObject check;
	[SerializeField]
	private GameObject effect;
	
	[SerializeField]
	private AudioClip se_check; 
	[SerializeField]
	private AudioClip se_bag; 
	
	[SerializeField]
	private Transform marker;
	
	[SerializeField]
	Transform target;
	// Use this for initialization
	void Awake () {
		this.isChecked = false;
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			if(!isChecked ){
				this.isChecked = true;
				
				// check
				GameObject obj = Instantiate(check, marker.position + new Vector3(0,5,0), marker.rotation) as GameObject;
				//obj.transform.SetParent(marker);
				Debug.Log(this.gameObject.name + " has been checked");
				
				// effect
				obj = Instantiate(effect) as GameObject;
				obj.transform.position = new Vector3 (target.position.x, 0, target.position.z);
				//objtransform.SetParent(target);
				
				PlaySE();
				
				if(this.transform.childCount > 0){
					Destroy(this.transform.GetChild(0).gameObject);
				}
			}
		}
	}
	
	private void PlaySE(string se="Checked"){
		if(se == "Checked"){
			this.GetComponent<AudioSource>().PlayOneShot(se_check);
		}else{
			this.GetComponent<AudioSource>().PlayOneShot(se_bag);
		}
	}
}
