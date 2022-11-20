using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    //선택된 캐릭터를 가져옴
    public Character character;
    //선택이 된 캐릭터들과 되지 않은 캐릭터들의 색깔을 바꾸기위한 스프라이트 랜더러
    SpriteRenderer sr;
    //선택된 캐릭터를 확인하기 위한 배열
    public SelectChar[] Sch;

    //select 메뉴의 각 캐릭터들의 위치를 가져옴
    Transform tr1;
    Transform tr2;
    Transform tr3;


    void Start()
    {
        //각 캐릭터의 위치를 가져옴 
        tr1= GameObject.FindWithTag("1").transform;
        tr2 = GameObject.FindWithTag("2").transform;
        tr3 = GameObject.FindWithTag("3").transform;

        sr = GetComponent<SpriteRenderer>();
        
        //초기화
        if (DataManager.instance.CurrentCharacter == character) Onselect();
        else OnDeselect();

    }
    //클릭하면 반응
    private void OnMouseUpAsButton()
    {
        DataManager.instance.CurrentCharacter=character;
        Onselect();
        for (int i = 0; i < Sch.Length; i++)
        {
            if (Sch[i] != this)
            {
                Sch[i].OnDeselect();
               
            }
                

        }
    }

    void OnDeselect()
    {
        //색 회색
        sr.material.color = new Color(73f / 255f, 73f / 255f, 73f / 255f);

        //선택이 된 캐릭터들의 y값 변경
        if (character == Character.Sorcerer)
        {
            tr1.transform.position = new(-5, 0.25f, 0);
        }
        else if (character == Character.Archor)
        {
            tr2.transform.position = new(0, 0.25f, 0);
        }
        else if (character == Character.Warrior)
        {
            tr3.transform.position = new(5, 0.25f, 0);
        }
    }

    void Onselect()
    {
        //색 흰색
        sr.material.color = new Color(1f, 1f, 1f);
        //선택이 된 캐릭터들의 y값 변경
        if (character== Character.Sorcerer)
        {
            tr1.transform.position=new (-5, 1, 0);
        }
        else if(character == Character.Archor)
        {
            tr2.transform.position = new(0, 1, 0);
        }
        else if (character == Character.Warrior)
        {
            tr3.transform.position = new(5, 1, 0);
        }
    }

       


}
