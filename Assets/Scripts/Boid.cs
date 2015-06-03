using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour
{
    GameObject boss;
    GameObject enemy;
    public static List<Boid> children = new List<Boid>();
    const float TurnSpeed = 0.05f;

    const float SeparationWeight = 5f;
    const float CohesionWeight = 1f;
    const float AlingmentWeight = 1f;
    const float Speed = 3f;

    // Use this for initialization
    void Start()
    {
        boss = GameObject.Find("Boss");
        enemy = GameObject.FindWithTag("Enemy");

        // 参照可能なリストへ自身を追加
        children.Add(this);

        // 初期の移動方向をランダムで決める
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
	
    // Update is called once per frame
    void Update()
    {
        Vector3 vector = Vector3.zero;

        // ３つのルールの結果を取得
        vector += Separation();
        vector += Cohesion();
        vector += Alingment();
        vector = vector.normalized * TurnSpeed;
		
        // 天敵による移動
        vector += Enemy();
			
        // 巡航方向への移動
        vector += Cruising();

        // 上下方向への移動は制限する
        vector.y = vector.y * 0.1f;

        vector *= Speed;

        // 移動、方向転換
        GetComponent<Rigidbody>().velocity = vector;
        transform.LookAt(transform.position + vector);
    }

    Vector3 Separation()
    {
        Vector3 change = Vector3.zero;
        int count = 0;
        foreach (Boid child in children)
        {
            // 自分自身は計算しない
            if (child.Equals(this))
            {
                continue;
            }
			
            // 自分との距離を取得
            float distance = Vector3.Distance(child.transform.position, this.transform.position);
						
            if (distance < 0.01f)
            {
                // 近すぎるのでランダムの方向へ緊急移動
                change += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                count++;
            }
            else if (distance < 0.4f)
            {
                // 別の個体と反対方向に移動する力
                change += (this.transform.position - child.transform.position).normalized;
                count++;
            }
        }

        change = count == 0 ? change : change / count;
              
        // 計算したベクトルの平均を返す 0の場合は初期値を返す
        return change * SeparationWeight;
    }

    Vector3 Cohesion()
    {
        // 群れの中心を求める
        Vector3 center = Vector3.zero;
        foreach (Boid child in children)
        {
            center += child.transform.position;
        }

        center /= children.Count;
        center += boss.transform.position;
        center /= 2f;
			
        // 中心に向かうベクトルを求める
        Vector3 change = center - this.transform.position;
        return change.normalized * CohesionWeight;
    }

    // 他の個体の移動方向にあわせようとする
    Vector3 Alingment()
    {
        Vector3 change = Vector3.zero;
        int count = 0;
        foreach (Boid child in children)
        {
            // 自分自身は計算しない
            if (child.Equals(this))
            {
                continue;
            }

            // 他の個体の移動方向を加算する
            change += child.GetComponent<Rigidbody>().velocity.normalized;
            count++;
        }
        
        // 計算したベクトルの平均を返す 0の場合は初期値を返す
        return count == 0 ? change : change / count * AlingmentWeight;
    }
		
    // 巡航
    Vector3 Cruising()
    {
        return GetComponent<Rigidbody>().velocity.normalized;
    }

    // 天敵が近くにいる場合
    Vector3 Enemy()
    {
        Vector3 change = Vector3.zero;

        // 敵が近くにいた場合緊急回避
        if (enemy != null)
        {
            if (Vector3.Distance(enemy.transform.position, this.transform.position) < 5f)
            {
                change = (this.transform.position - enemy.transform.position).normalized * 0.6f;
            }
        }
        return change;
    }
}
