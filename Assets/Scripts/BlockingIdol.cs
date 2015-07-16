using UnityEngine;
using System.Collections;

public class BlockingIdol : MonoBehaviour {

	private float defaultPosY;

	[SerializeField]
	private float moveOffsetPosY = 50f;
	private float moveTargetPosY = 0f;

	[SerializeField]
	private float moveSpeed = 2.5f;

	private bool blockFlug = false;

	// Use this for initialization
	void Start () {
		defaultPosY = this.transform.localPosition.y;

		if(moveOffsetPosY < 0){
			moveSpeed *= -1;
		}
		moveTargetPosY = defaultPosY + moveOffsetPosY;

	}
	
	// Update is called once per frame
	void Update () {
		if(blockFlug){
			float curPosY = this.transform.localPosition.y;
			float distance = Mathf.Abs( moveTargetPosY - curPosY );
			if( distance  <  0.1f ){
				blockFlug = false;
			}else{
				Vector3 newPos = this.transform.localPosition + new Vector3(0, moveSpeed * Time.deltaTime, 0);
			
				this.transform.localPosition = newPos;
			}
		}
	}



	public void Blocking(){
		blockFlug = true;

	}
}
