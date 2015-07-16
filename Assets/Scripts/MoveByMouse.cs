using UnityEngine;
using System.Collections;

public class MoveByMouse : MonoBehaviour {

	[SerializeField]
	private float moveSpeed = 10f;
	
	// Update is called once per frame
	void Update () {

		//this.transform.Rotate(0, 5 * Time.deltaTime, 0);
	
		float h = Input.GetAxis("Mouse X");
		float v = Input.GetAxis("Mouse Y");

		this.transform.Translate(h * moveSpeed * Time.deltaTime, 0, v * moveSpeed * Time.deltaTime );

	}
}
