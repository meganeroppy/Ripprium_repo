using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public bool isChecked {get; set;}

	[SerializeField]
	private GameObject check;
	// Use this for initialization
	void Awake () {
		this.isChecked = false;
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			if(!isChecked ){
				this.isChecked = true;
				GameObject obj = Instantiate(check, this.transform.position + new Vector3(0,5,0), this.transform.rotation) as GameObject;
				obj.transform.SetParent(this.transform);

				Debug.Log(this.gameObject.name + " has been checked");
			}
		}
	}

}
