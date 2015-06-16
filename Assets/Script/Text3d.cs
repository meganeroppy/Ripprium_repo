using UnityEngine;
using System.Collections;

public class Text3d : MonoBehaviour {

	GameObject player;
	TextMesh textMesh;
	float disappearDist = 30f;

	private void Awake(){
		textMesh = GetComponent<TextMesh>();
		player = GameObject.Find("Player");
		UpdateAlpha(0);
	}


	
	// Update is called once per frame
	void Update () {
	
		
	
	
		Vector3 diff = new Vector3(this.transform.position.x - player.transform.position.x, 0, this.transform.position.z - player.transform.position.z);
		float dot = Vector3.Dot(transform.forward, diff);
		
		
		if(dot < 0 && this.gameObject.name != "Text5"){
			UpdateAlpha(0);
			return;
		}                       

		float distance = diff.magnitude;
		
		if(gameObject.name.Equals("Text1")){
			
			
		}

		//if(distance >= 20){
			float val = (disappearDist - distance) / 10;
			//Debug.Log(val);
			UpdateAlpha(val);
		//}
	
	}

	private void UpdateAlpha(float newAlpha){
		Color col = textMesh.color;
		Color newColor = new Color(col.r, col.g, col.b, newAlpha);
		textMesh.color = newColor;

	}
}
