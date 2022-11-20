using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//직업을 구분 할 이넘
public enum Character
{
    Sorcerer, Archor,Warrior
}

public class DataManager : MonoBehaviour
{
    //싱글톤
    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    //현재 직업을 확인할 변수
    public Character CurrentCharacter;

}
