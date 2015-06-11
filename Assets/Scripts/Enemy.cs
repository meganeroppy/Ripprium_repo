using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	[SerializeField]
    float Speed = 10f;
    [SerializeField]
    float RotSpeed = 180f;

	Boss boss;

	void Awake(){
		boss = transform.parent.transform.GetChild(0).GetComponent<Boss>();
	}

    void Update()
    {
        // 群れの中心を求める
        Vector3 center = Vector3.zero;
		foreach (Boid child in boss.getBoid())
        {
            center += child.transform.position;
        }
        
		center /= boss.getBoid().Count;

        // ターゲットまでの角度を取得
        Vector3 vecTarget = center - transform.position;
        Vector3 vecForward = transform.TransformDirection(Vector3.forward);
        float angleDiff = Vector3.Angle(vecForward, vecTarget);
        float angleAdd = (RotSpeed * Time.deltaTime);
        Quaternion rotTarget = Quaternion.LookRotation(vecTarget);

        if (angleDiff <= angleAdd)
        {
            // ターゲットが回転角以内なら完全にターゲットの方を向く
            transform.rotation = rotTarget;
        }
        else
        {
            // ターゲットが回転角の外なら、指定角度だけターゲットに向ける
            float t = (angleAdd / angleDiff);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, t);
        }
        
        // 前進
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * Speed;
    }
}
