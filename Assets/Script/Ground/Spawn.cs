using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //배열 프리팹을 선언하여 각 직업을 가져옴
    public GameObject[] charPrefab;
    GameObject player;

    void Start()
    {
        //선택된 직업이 소서러일경우
        if (DataManager.instance.CurrentCharacter==Character.Sorcerer)
        {
            
            player = Instantiate(charPrefab[0], transform.position, Quaternion.identity);
            player.SetActive(true);
        }

        //선택된 직업이 궁수일 경우
        if (DataManager.instance.CurrentCharacter == Character.Archor)
        {
           
            player = Instantiate(charPrefab[1], transform.position, Quaternion.identity);
            player.SetActive(true);
        }

        //선택된 직업이 전사일 경우
        if (DataManager.instance.CurrentCharacter == Character.Warrior)
        {
           
            player = Instantiate(charPrefab[2], transform.position, Quaternion.identity);
            player.SetActive(true);
        }
    }

}
