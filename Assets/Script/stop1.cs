using UnityEngine;
using System.Collections;

public class stop1 : MonoBehaviour {
	public Transform th;
	public GameObject a;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	float o = th.transform.localPosition.y;
		if( o > 0){
			a.SetActive(false);
	}
}
}
