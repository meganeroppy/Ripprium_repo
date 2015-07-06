using UnityEngine;
using System.Collections;

public class IndicatorB : TextSprite {
	
	private const int ICON_NUM = 5;
	private SpriteRenderer[] icons = new SpriteRenderer[5];
	
	[SerializeField]
	private Sprite incomplete;
	[SerializeField]
	private Sprite done;
	[SerializeField]
	private Check check;
	
	private const float transparancyLate = 0.5f;
	
	protected override void Start(){
		player = GameObject.Find("Player");
		
		
		for(int i = 0 ; i < ICON_NUM ; i++){
			icons[i] = this.transform.GetChild(i).GetComponent<SpriteRenderer>();
			//icons[i].sprite = incomplete;
			UpdateAlpha(transparancyLate, icons[i]);
		}
		
		availableFromBack = true;
	}
	
	// Update is called once per frame
	protected override void Update () {
		
		Vector3 diff = new Vector3(this.transform.position.x - player.transform.position.x, 0, this.transform.position.z - player.transform.position.z);
		float distance = diff.magnitude;
		float val = (disappearDist - distance) / 10;
		val = val > 1 ? 1 : val < 0 ? 0 : val;
		
		
		for(int i = 0 ; i < ICON_NUM ; i++){
			bool flug = Goal.check[i];
			float newAlphaBase = 0f;
			if(flug){
				if(icons[i].transform.childCount == 0 && i != 4){
					Check obj = Instantiate(check);
					obj.transform.SetParent(icons[i].transform);
					obj.transform.localPosition = Vector3.zero;
					obj.transform.localRotation = Quaternion.identity;
					obj.transform.localScale = Vector3.one;
				}
				newAlphaBase = 1;
				
			}else{
				newAlphaBase = transparancyLate;
			}
			//icons[i].sprite = incomplete;
			UpdateAlpha(newAlphaBase * val, icons[i]);
		}
		
	}	
	
	protected override void UpdateAlpha(float val, SpriteRenderer target){
		Color col = target.color;
		Color newColor = new Color(col.r, col.g, col.b, val);
		target.color = newColor;
	}}
