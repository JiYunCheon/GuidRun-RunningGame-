using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererAttack : Attacks
{
    //SetActive�� Ȱ��ȭ�� ������ ����
    private void OnEnable()
    {
        //��ġ�� �ʱ�ȭ�ϰ� 
        transform.position = Vector2.zero;
        //Weapon�ױ׸� ã��
        Tr = GameObject.FindWithTag("Weapon").transform;
        //�� ��ġ�� ������
        transform.position=Tr.transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.isgameOver == true) return;

        //��ų ������ �ƴ϶�� 
        if (socerer_Skill_Attack == false)
        {
            totalTime += Time.deltaTime;
            //1�ʰ� �Ѿ�� 
            if (totalTime > 1f)
            {
                totalTime = 0;
                //������ ��ü�� false ��Ŵ 
                Sorcerer_Attack_false(sorcerer);
            }
            //������ �̵��ӵ�
            Attack_Speed(1f);
        }
        //��ų �����̶�� 
        if (socerer_Skill_Attack == true)
        {
            color.material.color = Color.red;
            //������ �̵��ӵ�
            Attack_Speed(0.5f);

            skill_Time += Time.deltaTime;
            //10�ʰ� �Ѿ�� 
            if (skill_Time > 6f)
            {
                skill_Time = 0;
                //������Ʈ�� �ı��ϰ�
                Destroy(gameObject);
                //��ų���� ���¸� �����Ѵ�
                socerer_Skill_Attack = false;
                FindObjectOfType<Sorcerer>().Sorcerer_Skill = socerer_Skill_Attack;
               
            }
            //������ �ٲ۴�.
           

        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //��ų�� Ʈ�������� ���� �� ������ ���
        if(other.gameObject.tag=="Monster")
        {
            //��ų������ �ƴ� ���
            if (socerer_Skill_Attack == false)
            {
                //�������.
                gameObject.SetActive(false);
            }
                
        }
    }

    


}
