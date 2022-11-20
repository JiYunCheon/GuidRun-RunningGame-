using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorAttack : Attacks
{



    //SetActive가 활성화될 때마다 실행
    private void OnEnable()
    {
        //포지션을 리셋하고 
        transform.position = Vector2.zero;
        //Weapon테그를 찾아 
        Tr = GameObject.FindWithTag("Weapon").transform;
        //그 위치를 가져옴 
        transform.position = Tr.transform.position;
        transform.localScale = new Vector3(2, 0.2f, 0);


        color.material.color = Color.yellow;
    }

    void Update()
    {
        //플레이어가 게임오버 상태이면 리턴
        if (GameManager.Instance.isgameOver == true) return;

        //공격의 이동속도
        Attack_Speed(2);

        totalTime += Time.deltaTime;

        if (FindObjectOfType<Archor>().Archor_Skill == true)
        {
            color.material.color = Color.red;
        }

        //2초가 넘어가면 
        if (totalTime > 2f)
        {
            totalTime = 0;
            //SetActive를 false시킴 
            Archor_Attack_false(archor);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bool three = GameManager.Instance.archor_Attack;

        
        if (other.gameObject.tag == "Monster"&&three == true)
        {
            return;
        }

        else if (other.gameObject.tag=="Monster"&& three == false)
        {
           
           gameObject.SetActive(false);
           

        }
    }


}
