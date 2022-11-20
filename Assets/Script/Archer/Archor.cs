using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archor : ObjectPool<ArchorAttack>
{
    //Archor의 공격 프리팹 
    public ArchorAttack Attackprefab;
    //풀링의 개수 제한 
    private int AttackCount = 100;

    //Archor의 스킬 
    public ArchorAttack []archor_skill_count = null;

    //기본 공격을 확인하는 변수 
    public bool archerattack = false;
    //스킬 공격을 확인하는 변수
    public bool Archor_Skill = false;

    Renderer color;

    //오브젝트의 SetActive가 false가 되면 사라진 프리팹을 가져옴 
    public override ArchorAttack CreatePool()
    {
        return Attackprefab;
    }

    


    void Start()
    {
        //Archor의 스킬시 발사되는 공격 개수 제한
        archor_skill_count = new ArchorAttack[10];
        //풀링의 개수제한
        Pool_Max_Size = AttackCount;
        color = GetComponent<Renderer>();
    }

    void Update()
    {
        //플레이어가 게임오버 상태이면 리턴
        if (GameManager.Instance.isgameOver == true) return;

        //A키를 누를 시 
        if (Input.GetKeyDown(KeyCode.A))
        {

            //오브젝트를 생성 
            Get();
            
        }


        //S키를 누르고 플레이어 MP가 꽉 찬경우 
        if (Input.GetKeyUp(KeyCode.S) && GameManager.Instance.PlayerMp >= 0.9f)
        {
           
            //0.2초씩 발싸되는 코루틴 시작 
            StartCoroutine(threeArrow());
            //플레이어 MP를 0으로 바꾸고 
            GameManager.Instance.PlayerMp = 0;
            //마나통을0으로 줄임 
            GameManager.Instance.mpTrans.localScale = new Vector3(0f, 0.7f, 1);
        }

        //0.2초간 5발 생성 코루틴
        IEnumerator threeArrow()
        {
            int i = 0;
            while(true)
            {
                archor_skill_count[i] = Instantiate(Attackprefab, transform.position, Quaternion.identity);
                archor_skill_count[i].transform.localScale=new Vector3(4, 1.5f, 0);
                archor_skill_count[i].color.material.color = Color.red;
                yield return new WaitForSeconds(1f);
                i++;
                if (i>6)
                {
                    
                    break;
                }
            }
            
        }


    }
}
