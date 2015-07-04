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
	
	private Color defaultFogColor = new Color(0.302f, 0.753f, 0.978f, 0.203f);
	private Color darkenFogColor = new Color(0.493f, 0.004f, 0.372f, 0.203f);
		
	private void Awake(){
		mesh = GetComponent<MeshRenderer>();
	//	defaultFogColor = RenderSettings.fogColor;
	//	Debug.Log(defaultFogColor);
	}
	
	// Update is called once per frame
	void Update () {
		
		pickedUp = flugObject == null;
		
		this.displayItems = inRange;
		
		for(int i = 0 ; i < this.transform.childCount ; i++){
			this.transform.GetChild(i).gameObject.SetActive(displayItems && !pickedUp);
		}
		
		RenderSettings.fogColor = this.displayItems  && !pickedUp ? darkenFogColor : defaultFogColor;
		
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
