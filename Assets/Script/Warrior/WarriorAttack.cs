using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttack : Attacks
{

    void Update()
    {
        //a키가 눌렸을때 검이 한바퀴 회전 
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(DownSword());
        }
       
    }

    IEnumerator DownSword()
    {
        int count = 0;
        while (true)
        {
            if (count == 45)
            {
                count = 0;
                break;
            }
            
            count++;
            transform.Rotate(0, 0, -8f + Time.deltaTime);
            yield return new WaitForSeconds(0.01f);

        }

    }
    



}
