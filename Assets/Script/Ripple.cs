using UnityEngine;
using System.Collections;

public class Ripple : MonoBehaviour {

	[SerializeField]
	private int textureIndex = 0;


	[SerializeField]
	private Texture[] myTextures;

	private ParticleSystemRenderer par;
	private ParticleSystem parSys;
	
	private AudioSource audio;
	[SerializeField]
	private AudioClip clip;

	// Use this for initialization
	void Awake () {
		par = GetComponent<ParticleSystemRenderer>();
		parSys = GetComponent<ParticleSystem>();
		parSys.playOnAwake = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		par.material.mainTexture = myTextures[textureIndex % myTextures.Length];
	}

	public void Create(bool withDestroy=false){
		Debug.Log("Create");
		parSys.Play();
		audio.PlayOneShot(clip);
		if(withDestroy){
			Destroy(this.gameObject, 1.0f);
		}
	}
}
