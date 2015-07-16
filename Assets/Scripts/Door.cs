using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	[SerializeField]
	private float rotOffsetY = 120f; //degree
	private float defaultRotY = 0f; // degree
	private float targetRot = 0f; // degree
	
	[SerializeField]
	private float rotSpeed = 15f;

	[SerializeField]
	private bool clockwise = true;

	private bool opening = false;
	
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		defaultRotY = this.transform.rotation.eulerAngles.y;
		targetRot = defaultRotY + rotOffsetY;
		
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(opening){
			float curRotY = this.transform.rotation.eulerAngles.y;
			float diff = Mathf.Abs( targetRot - curRotY );
		Debug.Log(diff);
			if( diff  <  1.0f ){
					opening = false;
			}else{
				float add = rotSpeed * Time.deltaTime * (clockwise ? 1 : -1);
				this.transform.Rotate(0, add, 0);
			}
		}
	}

	public void Open(){
		opening = true;
		audio.Play();
	}
}
