using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DarkScreen : MonoBehaviour {

	private Image image;
	private Text logo;

	[SerializeField]
	private float fadeSpeed = 0.15f;

	private float wait = 1.0f;
	private float m_darkAlpha = 0;
	private float m_logoAlpha = 0;

	private void Awake(){
		image = GetComponent<Image>();
		logo = this.transform.parent.GetChild(1).GetComponent<Text>();
		UpdateDarkAlpha(m_darkAlpha);
		UpdateLogoAlpha(m_logoAlpha);
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
		Color col = image.color;
		Color newColor = new Color(col.r, col.g, col.b, newAlpha);
		image.color = newColor;
	}

	private void UpdateLogoAlpha(float newAlpha){
		Color col = logo.color;
		Color newColor = new Color(col.r, col.g, col.b, newAlpha);
		logo.color = newColor;
	}
}
