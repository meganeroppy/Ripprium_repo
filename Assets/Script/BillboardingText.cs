using UnityEngine;
using System.Collections;

public class BillboardingText : MonoBehaviour {

	GameObject player;

	
	private void Awake(){
		player = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update () {
		
		this.transform.LookAt(player.transform);
	}
}
