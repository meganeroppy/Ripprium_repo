using UnityEngine;
using System.Collections;

public class Ripple_particle : MonoBehaviour {

	[SerializeField]
	private int textureIndex = 0;


	[SerializeField]
	private Texture[] myTextures;

	private ParticleSystemRenderer par;
	private ParticleSystem parSys;

	// Use this for initialization
	void Awake () {
		par = GetComponent<ParticleSystemRenderer>();
		parSys = GetComponent<ParticleSystem>();
		parSys.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
		par.material.mainTexture = myTextures[textureIndex % myTextures.Length];
	}

	public void Create(){
		Debug.Log("Create");
		parSys.Play();
	}
}
