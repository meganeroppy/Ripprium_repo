using UnityEngine;
using System.Collections;

public class TextSprite : MonoBehaviour {
	
	protected GameObject player;
	private SpriteRenderer myRenderer;
	protected float disappearDist = 30f;
	protected bool availableFromBack = false;
	
	protected virtual void Start(){
		myRenderer = GetComponent<SpriteRenderer>();
		player = GameObject.Find("Player");
		UpdateAlpha(0);
	}
	
	
	
	// Update is called once per frame
	protected virtual void Update () {
		
		Vector3 diff = new Vector3(this.transform.position.x - player.transform.position.x, 0, this.transform.position.z - player.transform.position.z);
		float dot = Vector3.Dot(transform.forward, diff);
		
		if(dot < 0 && ( this.gameObject.name != "Text5" && !this.gameObject.name.Contains("Marker")) && !availableFromBack){
			UpdateAlpha(0);
			return;
		}
		
		float distance = diff.magnitude;
		
		//if(distance >= 20){
		float val = (disappearDist - distance) / 10;
		val = val > 1 ? 1 : val < 0 ? 0 : val;
		//	Debug.Log("val=" + val + " dist=" + distance);
		UpdateAlpha(val);
		//}
		
	}
	
	protected virtual void UpdateAlpha(float val){
		if(myRenderer == null){
			return;
		}

		Color col = myRenderer.color;
		Color newColor = new Color(col.r, col.g, col.b, val);
		myRenderer.color = newColor;
	}
	
	protected virtual void UpdateAlpha(float val, SpriteRenderer target){
		Color col = target.color;
		Color newColor = new Color(col.r, col.g, col.b, val);
		target.color = newColor;
	}
}
