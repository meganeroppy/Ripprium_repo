using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public Transform PointB;
	private int _direction = 1;
	private float _pointA;
	
	// Use this for initialization
	IEnumerator Start ()
	{
//		Debug.Log(this.gameObject.name + "::Start()");
		_pointA = transform.position.x;
		while (true)
		{
			if (transform.position.x < _pointA)
			{
				_direction = 1;
			}
			if (transform.position.x > PointB.position.x)
			{
				_direction = -1;
			}
			transform.Translate(_direction * 2 * Time.deltaTime,0,0);
			yield return 0;
		}
	}
	// Use this for initialization

	// Update is called once per frame
	void Update () {
	
	}
}
