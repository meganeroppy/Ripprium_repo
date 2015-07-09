using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public Vector3 pos;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {/*
        // 群れの中心を求める
        Vector3 center = Vector3.zero;
        foreach (Boid child in Boid.children)
        {
            center += child.transform.position;
        }
        
        center /= Boid.children.Count;

        transform.position = center + pos;
        transform.LookAt(center);
        */
    }
}
