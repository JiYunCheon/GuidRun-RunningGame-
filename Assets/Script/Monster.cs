using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : Attacks
{
    bool allattack;
   
    float MonsterHP;

    public Renderer Monster_color;


    private void Awake()
    {
        GameManager.Instance.MonsterHP = this.MonsterHP;
        Monster_color = GetComponent<Renderer>();
    }
    
    private void OnEnable()
    {
        this.MonsterHP = 3;
        Monster_color.material.color = Color.white;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //���Ͱ� ��ų�� ������ 
        if (other.gameObject.tag == "Skill")
        {
            //���� ü���� ����

            Monster_color.material.color = Color.red;
            
            if(DataManager.instance.CurrentCharacter == Character.Archor)
            {

                this.MonsterHP -= 0.7f;

                if (arhor_Skill_Attack == false)
                {
                    
                    if (this.MonsterHP <= 0)
                    {
                        //���͸� ���� 
                        gameObject.SetActive(false);
                        //���ھ �ø�
                        GameManager.Instance.addScore(1);

                        GameManager.Instance.MpControll();
                    }
                }
               
               

            }

            else if (DataManager.instance.CurrentCharacter == Character.Sorcerer)
            {
                this.MonsterHP--;

                if (this.MonsterHP <= 0&& socerer_Skill_Attack == false)
                {
                    //���͸� ���� 
                    gameObject.SetActive(false);
                    //���ھ �ø�
                    GameManager.Instance.addScore(1);
                    this.MonsterHP = 0;
                    GameManager.Instance.MpControll();
                    return;
                }
                
                else if (FindObjectOfType<Sorcerer>().Sorcerer_Skill == true)
                {
                    
                    GameManager.Instance.addScore(1);
                    gameObject.SetActive(false);
                    return;
                }
                    
            }

            else if (DataManager.instance.CurrentCharacter == Character.Warrior)
            {
                this.MonsterHP-=2;
                if (this.MonsterHP <= 0&& FindObjectOfType<SwordSkill>().Warrior_Skill == false)
                {
                    //���͸� ���� 
                    gameObject.SetActive(false);
                    //���ھ �ø�
                    GameManager.Instance.addScore(1);
                    MonsterHP = 0;
                    GameManager.Instance.MpControll();
                }
                else if (FindObjectOfType<SwordSkill>().Warrior_Skill==true)
                {
                    
                    gameObject.SetActive(false);
                    GameManager.Instance.addScore(1);
                    GameManager.Instance.PlusHP(1);
                }

            }

        }

        //�÷��̾ ������ 
        if(other.gameObject.tag == "Player")
        {
            //ü���� ���� 
            GameManager.Instance.HpControll();
            
            //�÷��̾��� ü���� 0���� ������
            if (GameManager.Instance.PlayerHp <= 0)
            {
                //���� ���¸� ���ӿ����� �ٲٰ� �÷��̾ ���� 
                GameObject pc = GameObject.FindWithTag("Player");
                GameManager.Instance.Die();
                pc.SetActive(false);
            }
        }

    }
}
