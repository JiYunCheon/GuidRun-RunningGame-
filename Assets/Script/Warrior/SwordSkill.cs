using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : Attacks
{
    public bool Warrior_Skill;

    void Update()
    {
        //sŰ�� ������ ������ �� �������� 
        if (Input.GetKeyDown(KeyCode.S) && GameManager.Instance.PlayerMp >= 0.9f && Warrior_Skill == false)
        {
            Warrior_Skill = true;
            //�ݶ��̴��� �������� ������ 5�ʵڿ� ����
            StartCoroutine(OnSwordSkill(10f));
            //������ 0���� �����
            GameManager.Instance.PlayerMp = 0;
            //�������� 0���� �ٲ� 
            GameManager.Instance.mpTrans.localScale = new Vector3(0f, 0.7f, 1);
        }
    }




    //�ݶ��̴��� �������� ������ 5�ʵڿ� ����
    IEnumerator OnSwordSkill(float onSkill)
    {

        sr.enabled = true;
        bc.enabled = true;

        yield return new WaitForSeconds(onSkill);

        sr.enabled = false;
        bc.enabled = false;
        Warrior_Skill = false;
    }



    public void TRUE()
    {
        gameObject.SetActive(true);
    }
    public void FALSE()
    {
        gameObject.SetActive(false);
    }

}
