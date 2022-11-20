using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererAttack : Attacks
{
    //SetActive가 활성화될 때마다 실행
    private void OnEnable()
    {
        //위치를 초기화하고 
        transform.position = Vector2.zero;
        //Weapon테그를 찾아
        Tr = GameObject.FindWithTag("Weapon").transform;
        //그 위치를 가져옴
        transform.position=Tr.transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.isgameOver == true) return;

        //스킬 공격이 아니라면 
        if (socerer_Skill_Attack == false)
        {
            totalTime += Time.deltaTime;
            //1초가 넘어가면 
            if (totalTime > 1f)
            {
                totalTime = 0;
                //생성된 객체를 false 시킴 
                Sorcerer_Attack_false(sorcerer);
            }
            //공격의 이동속도
            Attack_Speed(1f);
        }
        //스킬 공격이라면 
        if (socerer_Skill_Attack == true)
        {
            color.material.color = Color.red;
            //공격의 이동속도
            Attack_Speed(0.5f);

            skill_Time += Time.deltaTime;
            //10초가 넘어가면 
            if (skill_Time > 6f)
            {
                skill_Time = 0;
                //오브젝트를 파괴하고
                Destroy(gameObject);
                //스킬공격 상태를 해제한다
                socerer_Skill_Attack = false;
                FindObjectOfType<Sorcerer>().Sorcerer_Skill = socerer_Skill_Attack;
               
            }
            //색깔을 바꾼다.
           

        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //스킬의 트리거존에 들어온 게 몬스터일 경우
        if(other.gameObject.tag=="Monster")
        {
            //스킬공격이 아닐 경우
            if (socerer_Skill_Attack == false)
            {
                //사라진다.
                gameObject.SetActive(false);
            }
                
        }
    }

    


}
