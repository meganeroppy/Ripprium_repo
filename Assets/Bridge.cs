using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour {
	
	[SerializeField]
	Transform player;
	
	public bool inRange{get; set;}
	
	private bool displayItems = false;
	private bool pickedUp = false;
	
	[SerializeField]
	private GameObject flugObject;
	
	[SerializeField]
	private Material[] materials = new Material[2];
	
	private MeshRenderer mesh;
	
	private bool touched = false;
		
	private void Awake(){
		mesh = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		pickedUp = flugObject == null;
		
		this.displayItems = inRange;
		
		for(int i = 0 ; i < this.transform.childCount ; i++){
			this.transform.GetChild(i).gameObject.SetActive(displayItems && !pickedUp);
		}
		
		mesh.material = displayItems && !pickedUp ? materials[1] : materials[0];
	}
	
	private void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			if(!inRange ){
				inRange = true;
			}
		}
	}
	
	private void OnTriggerExit(Collider col){
		if(col.tag == "Player"){
			if(inRange ){
				inRange = false;
			}
		}
	}
	
	

	
}
