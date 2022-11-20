using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archor : ObjectPool<ArchorAttack>
{
    //Archor�� ���� ������ 
    public ArchorAttack Attackprefab;
    //Ǯ���� ���� ���� 
    private int AttackCount = 100;

    //Archor�� ��ų 
    public ArchorAttack []archor_skill_count = null;

    //�⺻ ������ Ȯ���ϴ� ���� 
    public bool archerattack = false;
    //��ų ������ Ȯ���ϴ� ����
    public bool Archor_Skill = false;

    Renderer color;

    //������Ʈ�� SetActive�� false�� �Ǹ� ����� �������� ������ 
    public override ArchorAttack CreatePool()
    {
        return Attackprefab;
    }

    


    void Start()
    {
        //Archor�� ��ų�� �߻�Ǵ� ���� ���� ����
        archor_skill_count = new ArchorAttack[10];
        //Ǯ���� ��������
        Pool_Max_Size = AttackCount;
        color = GetComponent<Renderer>();
    }

    void Update()
    {
        //�÷��̾ ���ӿ��� �����̸� ����
        if (GameManager.Instance.isgameOver == true) return;

        //AŰ�� ���� �� 
        if (Input.GetKeyDown(KeyCode.A))
        {

            //������Ʈ�� ���� 
            Get();
            
        }


        //SŰ�� ������ �÷��̾� MP�� �� ����� 
        if (Input.GetKeyUp(KeyCode.S) && GameManager.Instance.PlayerMp >= 0.9f)
        {
           
            //0.2�ʾ� �߽εǴ� �ڷ�ƾ ���� 
            StartCoroutine(threeArrow());
            //�÷��̾� MP�� 0���� �ٲٰ� 
            GameManager.Instance.PlayerMp = 0;
            //��������0���� ���� 
            GameManager.Instance.mpTrans.localScale = new Vector3(0f, 0.7f, 1);
        }

        //0.2�ʰ� 5�� ���� �ڷ�ƾ
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
