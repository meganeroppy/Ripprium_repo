using UnityEngine;
using System.Collections;

public class MysteryZone : MonoBehaviour {

	private bool displayItems = false;
	private bool pickedUp = false;
	
	[SerializeField]
	private GameObject flugObject;
	
	
	// Update is called once per frame
	void Update () {
	
		pickedUp = flugObject == null;
	
		for(int i = 0 ; i < this.transform.childCount ; i++){
			this.transform.GetChild(i).gameObject.SetActive(displayItems && !pickedUp);
		}
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			if(!displayItems ){
				this.displayItems = true;
			}
		}
	}
}
