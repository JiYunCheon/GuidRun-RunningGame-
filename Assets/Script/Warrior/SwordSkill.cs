using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkill : Attacks
{
    public bool Warrior_Skill;

    void Update()
    {
        //s키가 눌리고 마나가 꽉 차있으면 
        if (Input.GetKeyDown(KeyCode.S) && GameManager.Instance.PlayerMp >= 0.9f && Warrior_Skill == false)
        {
            Warrior_Skill = true;
            //콜라이더와 랜더러가 켜지고 5초뒤에 꺼짐
            StartCoroutine(OnSwordSkill(10f));
            //마나를 0으로 만들고
            GameManager.Instance.PlayerMp = 0;
            //마나통을 0으로 바꿈 
            GameManager.Instance.mpTrans.localScale = new Vector3(0f, 0.7f, 1);
        }
    }




    //콜라이더와 랜더러가 켜지고 5초뒤에 꺼짐
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
