using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : ObjectPool<SorcererAttack>
{
    //Sorcerer�� ���� ������
    public SorcererAttack Attackprefab;
    //���� Ǯ�� �������� 
    private int AttackCount=100;
    
    //�Ҽ����� ��ų
    public SorcererAttack Skill =null;

    //�Ҽ����� ��ų�� Ȯ�� 
    public bool Sorcerer_Skill=false;
    //�Ҽ����� �Ϲݰ����� Ȯ�� 
    public bool Sorcererattack = false;

    //������Ʈ�� SetActive�� false�� �Ǹ� ����� �������� ������ 
    public override SorcererAttack CreatePool()
    {
        return Attackprefab;
    }

    void Start()
    {
        //���� Ǯ�� �������� 
        Pool_Max_Size = AttackCount;
        
    }

    void Update()
    {
        //�÷��̾ ���ӿ��� �����̸� ����
        if (GameManager.Instance.isgameOver == true) return;
        //AŰ�� ���� �� 
        
        if (Input.GetKeyDown(KeyCode.A)&& Sorcerer_Skill ==false)
        {
            //�Ϲ� �������� Ȯ��
            Sorcererattack = true;
            //��ü ����
            Get();
        }

        //SŰ�� ������ �÷��̾� MP�� �� ����� 
        if (Input.GetKeyUp(KeyCode.S)&& GameManager.Instance.PlayerMp >= 0.9f)
        {
            //��ų ������ Ȯ��
            Sorcerer_Skill = true;
            //��ų�� ��ü ���� 
            Skill = Instantiate(Attackprefab, transform.position, Quaternion.identity);
            //ũ�⸦ Ű��
            Skill.transform.localScale = new Vector3(10, 10, 1);
            //�÷��̾��� ������ 0���� �����
            GameManager.Instance.PlayerMp = 0;
            //�������� 0���� �ٲ� 
            GameManager.Instance.mpTrans.localScale = new Vector3(0f, 0.7f, 1);
        }

       


    }
}
