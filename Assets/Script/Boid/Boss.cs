using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour
{
	public List<Boid> children = new List<Boid>();
	private Vector3 originPos;
	
    // Use this for initialization
    void Start()
    {
		originPos = this.transform.position;
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.position = originPos + new Vector3(Mathf.Cos(Time.time * 0.2f) * 10f, 0f, Mathf.Sin(Time.time * 0.2f) * 10f);
    }

	public void AddToBoid(Boid child){
		this.children.Add(child);
	}

	public List<Boid> getBoid(){
		return this.children;
	}
}
