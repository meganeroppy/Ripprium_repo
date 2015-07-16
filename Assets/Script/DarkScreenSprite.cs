using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DarkScreenSprite : MonoBehaviour {
	
	private SpriteRenderer screen;
	private SpriteRenderer logo;
	
	[SerializeField]
	private float fadeSpeed = 0.15f;
	
	private float wait = 1.0f;
	private float m_darkAlpha = 0;
	private float m_logoAlpha = 0;
	
	private void Start(){
		screen = GetComponent<SpriteRenderer>();
		logo = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
		UpdateDarkAlpha(m_darkAlpha);
		UpdateLogoAlpha(m_logoAlpha);
		
		if(UnityEditor.PlayerSettings.virtualRealitySupported){
			Debug.Log("DarkScreen Adjusted for Oculus");
			this.transform.localScale = new Vector3(4,4,4);
			this.transform.GetChild(0).transform.localScale = new Vector3(0.005f, 0.005f, 0.002f);
		}
	}
	
	private void Update(){
		
		if(!Goal.completed){
			return;
		}
		
		if(m_darkAlpha < 1){
			m_darkAlpha += Time.deltaTime * fadeSpeed;
			UpdateDarkAlpha(m_darkAlpha);
		}else{
			if(wait < 0){
				m_logoAlpha += Time.deltaTime * fadeSpeed;
				UpdateLogoAlpha(m_logoAlpha);
			}else{
				wait -= Time.deltaTime;
			}
		}
		
		
	}
	
	
	private void UpdateDarkAlpha(float newAlpha){
		Color col = screen.color;
		Color newColor = new Color(col.r, col.g, col.b, newAlpha);
		screen.color = newColor;
	}
	
	private void UpdateLogoAlpha(float newAlpha){
		Color col = logo.color;
		Color newColor = new Color(col.r, col.g, col.b, newAlpha);
		logo.color = newColor;
	}
}
