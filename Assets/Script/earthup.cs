using UnityEngine;
using System.Collections;

public class earthup : MonoBehaviour {
	public Transform th;
	public Transform a;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float j = a.transform.localPosition.x;
		float k = a.transform.localPosition.z;
		if ((j >-55.7f)&(k >97.2f)) {
			if(j < -24.4f){
			th.transform.Translate (0, 0.05f, 0);
			
			}
		}


}
}
