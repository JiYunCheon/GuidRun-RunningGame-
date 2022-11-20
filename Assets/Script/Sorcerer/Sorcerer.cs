using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : ObjectPool<SorcererAttack>
{
    //Sorcerer의 공격 프리팹
    public SorcererAttack Attackprefab;
    //공격 풀링 개수제한 
    private int AttackCount=100;
    
    //소서러의 스킬
    public SorcererAttack Skill =null;

    //소서러의 스킬을 확인 
    public bool Sorcerer_Skill=false;
    //소서러의 일반공격을 확인 
    public bool Sorcererattack = false;

    //오브젝트의 SetActive가 false가 되면 사라진 프리팹을 가져옴 
    public override SorcererAttack CreatePool()
    {
        return Attackprefab;
    }

    void Start()
    {
        //공격 풀링 개수제한 
        Pool_Max_Size = AttackCount;
        
    }

    void Update()
    {
        //플레이어가 게임오버 상태이면 리턴
        if (GameManager.Instance.isgameOver == true) return;
        //A키를 누를 시 
        
        if (Input.GetKeyDown(KeyCode.A)&& Sorcerer_Skill ==false)
        {
            //일반 공격임을 확인
            Sorcererattack = true;
            //객체 생성
            Get();
        }

        //S키를 누르고 플레이어 MP가 꽉 찬경우 
        if (Input.GetKeyUp(KeyCode.S)&& GameManager.Instance.PlayerMp >= 0.9f)
        {
            //스킬 공격을 확인
            Sorcerer_Skill = true;
            //스킬을 객체 생성 
            Skill = Instantiate(Attackprefab, transform.position, Quaternion.identity);
            //크기를 키움
            Skill.transform.localScale = new Vector3(10, 10, 1);
            //플레이어의 마나를 0으로 만들고
            GameManager.Instance.PlayerMp = 0;
            //마나통을 0으로 바꿈 
            GameManager.Instance.mpTrans.localScale = new Vector3(0f, 0.7f, 1);
        }

       


    }
}
