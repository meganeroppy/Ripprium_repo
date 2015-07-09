using UnityEngine;
using System.Collections;

public class Check : TextSprite {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		this.GetComponent<SpriteRenderer>().color = Color.green;
		availableFromBack = true;
	}
	

}
