using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //�迭 �������� �����Ͽ� �� ������ ������
    public GameObject[] charPrefab;
    GameObject player;

    void Start()
    {
        //���õ� ������ �Ҽ����ϰ��
        if (DataManager.instance.CurrentCharacter==Character.Sorcerer)
        {
            
            player = Instantiate(charPrefab[0], transform.position, Quaternion.identity);
            player.SetActive(true);
        }

        //���õ� ������ �ü��� ���
        if (DataManager.instance.CurrentCharacter == Character.Archor)
        {
           
            player = Instantiate(charPrefab[1], transform.position, Quaternion.identity);
            player.SetActive(true);
        }

        //���õ� ������ ������ ���
        if (DataManager.instance.CurrentCharacter == Character.Warrior)
        {
           
            player = Instantiate(charPrefab[2], transform.position, Quaternion.identity);
            player.SetActive(true);
        }
    }

}
