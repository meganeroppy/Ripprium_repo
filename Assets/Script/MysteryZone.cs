using UnityEngine;
using System.Collections;

public class MysteryZone : MonoBehaviour {

	private bool displayItems = false;
	private bool pickedUp = false;
	
	[SerializeField]
	private GameObject flugObject;
	
	[SerializeField]
	private Material[] bridgeMaterials = new Material[2];
	
	private MeshRenderer bridgeMesh;
	
	private bool touched = false;
	
	private Bridge bridge;
	
	
	private void Awake(){
		bridge = GameObject.Find("Old_Bridge").GetComponent<Bridge>();
		bridgeMesh = bridge.gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		pickedUp = flugObject == null;
		
		this.displayItems = bridge.inRange;
	
		for(int i = 0 ; i < this.transform.childCount ; i++){
			this.transform.GetChild(i).gameObject.SetActive(displayItems && !pickedUp);
		}
		
		bridgeMesh.material = displayItems && !pickedUp ? bridgeMaterials[1] : bridgeMaterials[0];
		
	}
}
