using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
	    
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(Time.time * 0.2f) * 10f, 0f, Mathf.Sin(Time.time * 0.2f) * 10f);
    }
}
