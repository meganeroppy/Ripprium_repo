using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public ArrayList checkPoints = new ArrayList();
	public static bool[] check = new bool[5];
	public static bool clearFlug = false;
	public static bool completed = false;
	[SerializeField]
	private GameObject effect;
	
	[SerializeField]
	private AudioClip se_clearFlug;
	
	
	private void Start(){
		checkPoints = GetCheckPoints();
	}
	
	private void Update(){
		if(checkPoints.Count <= 0){
			return;
		}
		
		for(int i = 0 ; i < checkPoints.Count ; i++){
			CheckPoint obj = (checkPoints[i] as GameObject).GetComponent<CheckPoint>();
			check[i] = obj.isChecked;
			if(!check[i]){
				return;
			}	
		}
		
		check[4] = true;

		if(!clearFlug){
			Debug.Log("ClearFlug");
			clearFlug = true;
			GameObject obj = Instantiate(effect);
			obj.transform.SetParent(GameObject.Find("Bed").transform);
			
			this.GetComponent<AudioSource>().PlayOneShot(se_clearFlug);
			
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

	private void OnTriggerEnter(Collider col){
		if(!clearFlug){
			return;
		}

		if(col.tag == "Player"){
			if(!completed ){
				completed = true;
				Debug.Log("Game Clear");
			}
		}
	}
	
	
}