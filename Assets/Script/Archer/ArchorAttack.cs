using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchorAttack : Attacks
{



    //SetActive�� Ȱ��ȭ�� ������ ����
    private void OnEnable()
    {
        //�������� �����ϰ� 
        transform.position = Vector2.zero;
        //Weapon�ױ׸� ã�� 
        Tr = GameObject.FindWithTag("Weapon").transform;
        //�� ��ġ�� ������ 
        transform.position = Tr.transform.position;
        transform.localScale = new Vector3(2, 0.2f, 0);


        color.material.color = Color.yellow;
    }

    void Update()
    {
        //�÷��̾ ���ӿ��� �����̸� ����
        if (GameManager.Instance.isgameOver == true) return;

        //������ �̵��ӵ�
        Attack_Speed(2);

        totalTime += Time.deltaTime;

        if (FindObjectOfType<Archor>().Archor_Skill == true)
        {
            color.material.color = Color.red;
        }

        //2�ʰ� �Ѿ�� 
        if (totalTime > 2f)
        {
            totalTime = 0;
            //SetActive�� false��Ŵ 
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
