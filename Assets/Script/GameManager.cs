using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : Singleton<GameManager>
{
    //���� ���¸� Ȯ��
    public bool isgameOver = false;
    //�÷��̾� HP MP�� ������Ƽ ����
    public float PlayerHp { set; get; } = 10;
    public float PlayerMp { set; get; } = 0;

    //ü�� ������ Transform�� ������ ����
    Transform hpTrans;
    public Transform mpTrans;

    //UI�� �� ������ �ٲ� ����
    public Text ScoreText;
    public GameObject GameOverText;
    public bool archor_Attack { set; get; } = false;

    //���ϴ� ���ھ Ȯ���ϴ� ����
    int score =0;


    public float MonsterHP = 3;


    private void Awake()
    {
        //��ũ�� �̿��Ͽ� Transform�� ã��
        hpTrans = GameObject.FindWithTag("Hp").transform;
        mpTrans= GameObject.FindWithTag("Mp").transform;
    }
    
    public void HpControll()
    {
        //�÷��̾��� ü���� ���� 
        PlayerHp -= 1;
        //ü�¹��� �������� ����
        hpTrans.localScale = new Vector3(((PlayerHp / 10) - 0.05f), 0.7f, 1);
    }

    public void MpControll()
    {
        //������ 0.9�̻��̶�� 
        if (PlayerMp >= 0.9f)
        {
            //�÷��̾� ������ 0.9�� �����ϰ�
            PlayerMp = 0.9f;
            //�������� �ִ� ����ũ��� �ٲ�
            mpTrans.localScale = new Vector3(0.95f, 0.7f, 1);
            return;
        }
        //���� ��� ��
        PlayerMp += 0.3f;
        //�������� �ø�
        mpTrans.localScale = new Vector3(PlayerMp, 0.7f, 1);

        //������ 0.9�̻��̶�� 
        if (PlayerMp >= 0.9f)
        {
            //�÷��̾� ������ 0.9�� �����ϰ�
            PlayerMp = 0.9f;
            //�������� �ִ� ����ũ��� �ٲ�
            mpTrans.localScale = new Vector3(0.95f, 0.7f, 1);
            return;
        }

    }

    //������ ���ӿ��� ���
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
        //�÷��̾��� ü���� ���� 
        PlayerHp += addHp;
        //ü�¹��� �������� �ø�
        hpTrans.localScale = new Vector3(((PlayerHp / 10) - 0.05f)+ addHp/10, 0.7f, 1);

        if (PlayerHp >= 10f)
        {
            PlayerHp = 10f;

            hpTrans.localScale = new Vector3(0.95f, 0.7f, 1);
            return;
        }

    }
}
