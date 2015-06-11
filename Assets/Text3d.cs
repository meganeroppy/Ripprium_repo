using UnityEngine;
using System.Collections;

public class Text3d : MonoBehaviour {

	GameObject player;
	TextMesh textMesh;
	float alpha;
	float disappearDist = 30f;

	private void Awake(){
		textMesh = GetComponent<TextMesh>();
		player = GameObject.Find("Player");
		alpha = textMesh.color.a;
	}


	
	// Update is called once per frame
	void Update () {

		float distance = new Vector3(this.transform.position.x - player.transform.position.x, 0, this.transform.position.z - player.transform.position.z).magnitude;

		if(distance >= 20){
			float val = (disappearDist - distance) / 10;
			Debug.Log(val);

			UpdateAlpha(val);
		}
	
	}

	private void UpdateAlpha(float newAlpha){
		Color col = textMesh.color;
		Color newColor = new Color(col.r, col.g, col.b, newAlpha);
		textMesh.color = newColor;

	}
}
