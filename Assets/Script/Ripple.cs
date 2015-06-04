using UnityEngine;
using System.Collections;

public class Ripple : MonoBehaviour {

	[SerializeField]
	private float lifeTime = 2.5f;
	private Vector3 myScale;
	private float timer = 0;
	[SerializeField]
	private float maxScale = 25;
	private Color[] colors =  new Color[8]{Color.red, Color.blue, Color.magenta, Color.white, Color.magenta, Color.yellow, Color.green, Color.cyan};
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private float gainRate = 1.5f;


	void Awake(){
		myScale = this.transform.localScale;
	}
	// Use this for initialization
	void Start () {
		float val = Random.Range(0, 90);
		this.transform.Rotate(0,val, 0);
		Color newColor = colors[Random.Range(0, colors.Length)];
		spriteRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
		spriteRenderer.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(myScale.x > maxScale || timer > lifeTime){
			Destroy(this.gameObject);
		}else{
			timer += Time.deltaTime;
			myScale *= gainRate;
			this.transform.localScale = myScale;
			
			SetAlpha((lifeTime - timer) / lifeTime);
		}
	}
	
	public void SetAlpha(float alpha){
		Color32 col = spriteRenderer.color;
		Color32 newColor = new Color(col.r, col.g, col.b, alpha);
		spriteRenderer.color = newColor;
	}
}
