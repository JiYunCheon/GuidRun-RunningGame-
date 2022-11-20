using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    //���õ� ĳ���͸� ������
    public Character character;
    //������ �� ĳ���͵�� ���� ���� ĳ���͵��� ������ �ٲٱ����� ��������Ʈ ������
    SpriteRenderer sr;
    //���õ� ĳ���͸� Ȯ���ϱ� ���� �迭
    public SelectChar[] Sch;

    //select �޴��� �� ĳ���͵��� ��ġ�� ������
    Transform tr1;
    Transform tr2;
    Transform tr3;


    void Start()
    {
        //�� ĳ������ ��ġ�� ������ 
        tr1= GameObject.FindWithTag("1").transform;
        tr2 = GameObject.FindWithTag("2").transform;
        tr3 = GameObject.FindWithTag("3").transform;

        sr = GetComponent<SpriteRenderer>();
        
        //�ʱ�ȭ
        if (DataManager.instance.CurrentCharacter == character) Onselect();
        else OnDeselect();

    }
    //Ŭ���ϸ� ����
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
        //�� ȸ��
        sr.material.color = new Color(73f / 255f, 73f / 255f, 73f / 255f);

        //������ �� ĳ���͵��� y�� ����
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
        //�� ���
        sr.material.color = new Color(1f, 1f, 1f);
        //������ �� ĳ���͵��� y�� ����
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
