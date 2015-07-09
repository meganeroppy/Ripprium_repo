using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour {

	[SerializeField]
	float rotSpeed = 1;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, rotSpeed, 0));
	}
}
