using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : Singleton<GameManager>
{
    //게임 상태를 확인
    public bool isgameOver = false;
    //플레이어 HP MP를 프로퍼티 선언
    public float PlayerHp { set; get; } = 10;
    public float PlayerMp { set; get; } = 0;

    //체력 마나의 Transform을 가져올 변수
    Transform hpTrans;
    public Transform mpTrans;

    //UI에 들어갈 내용을 바꿀 변수
    public Text ScoreText;
    public GameObject GameOverText;
    public bool archor_Attack { set; get; } = false;

    //변하는 스코어를 확인하는 변수
    int score =0;


    public float MonsterHP = 3;


    private void Awake()
    {
        //테크를 이용하여 Transform을 찾음
        hpTrans = GameObject.FindWithTag("Hp").transform;
        mpTrans= GameObject.FindWithTag("Mp").transform;
    }
    
    public void HpControll()
    {
        //플레이어의 체력을 깎음 
        PlayerHp -= 1;
        //체력바의 스케일을 줄임
        hpTrans.localScale = new Vector3(((PlayerHp / 10) - 0.05f), 0.7f, 1);
    }

    public void MpControll()
    {
        //마나가 0.9이상이라면 
        if (PlayerMp >= 0.9f)
        {
            //플레이어 마나를 0.9로 제한하고
            PlayerMp = 0.9f;
            //마나통을 최대 마나크기로 바꿈
            mpTrans.localScale = new Vector3(0.95f, 0.7f, 1);
            return;
        }
        //마나 상승 폭
        PlayerMp += 0.3f;
        //스케일을 늘림
        mpTrans.localScale = new Vector3(PlayerMp, 0.7f, 1);

        //마나가 0.9이상이라면 
        if (PlayerMp >= 0.9f)
        {
            //플레이어 마나를 0.9로 제한하고
            PlayerMp = 0.9f;
            //마나통을 최대 마나크기로 바꿈
            mpTrans.localScale = new Vector3(0.95f, 0.7f, 1);
            return;
        }

    }

    //점수와 게임오버 출력
    public void addScore(int score)
    {
        this.score += score;
        ScoreText.text = "Score : " + this.score;
    }
    public void Die()
    {
        isgameOver = true;
        GameOverText.SetActive(true);
    }
    public void PlusHP(float addHp)
    {
        //플레이어의 체력을 더함 
        PlayerHp += addHp;
        //체력바의 스케일을 늘림
        hpTrans.localScale = new Vector3(((PlayerHp / 10) - 0.05f)+ addHp/10, 0.7f, 1);

        if (PlayerHp >= 10f)
        {
            PlayerHp = 10f;

            hpTrans.localScale = new Vector3(0.95f, 0.7f, 1);
            return;
        }

    }
}
