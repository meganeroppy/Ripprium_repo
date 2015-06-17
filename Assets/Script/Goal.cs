using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	private ArrayList checkPoints = new ArrayList();
	private bool clearFlug = false;
	[SerializeField]
	private GameObject effect;
	
	private void Start(){
		checkPoints = GetCheckPoints();
	}
	
	private void Update(){
		if(checkPoints.Count <= 0){
			return;
		}
		
		
		for(int i = 0 ; i < checkPoints.Count ; i++){
			CheckPoint obj = (checkPoints[i] as GameObject).GetComponent<CheckPoint>();
			if(!obj.isChecked){
				return;
			}	
		}
		
		if(!clearFlug){
			Debug.Log("ClearFlug");
			clearFlug = true;
			Instantiate(effect, this.transform.position, Quaternion.identity);
		}
	
	}
	
	private ArrayList GetCheckPoints(){
		ArrayList objs = new ArrayList();
		
		for(int i = 0 ; i < 10 ; i++){
		
			string str = "CheckPoint" + i.ToString();
			GameObject obj = null;
			if(obj = GameObject.Find(str)){
				objs.Add(obj);
			}else{
				return objs;
			}
		}
		return objs;
	}
	
}