using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //������ ���� ������ �ٵ� ����
    private Rigidbody2D playerRigidbody;

    //������ 
    private float jump = 600f;
    //������ ������ ������ ���� 
    private int jumpCount = 0;
    //�÷��̾� ���� 
    Renderer color;

   


    void Start()
    {
        //���۳�Ʈ�� ������ 
        playerRigidbody = GetComponent<Rigidbody2D>();
        color = GetComponent<Renderer>();
    }
    
    void Update()
    {
        //���ӿ��������̸� ����
        if (GameManager.Instance.isgameOver == true) return;

        //�����̽��� ������ ����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //���� ������ ����
            if(jumpCount <10)
            {
                jumpCount++;
                playerRigidbody.AddForce(transform.up * jump);
            }
        }
        //��ư���� ���� ���� �ӵ��� ������ 
        else if(Input.GetKeyUp(KeyCode.Space)&& playerRigidbody.velocity.y>0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        //�÷��̾� ������ �� ����� ������ �ٲ�
        if (GameManager.Instance.PlayerMp >= 0.9f)
        {
            color.material.color = Color.blue;
        }
        //������ �� ����찡 �ƴ϶�� �⺻ ��
        else if (GameManager.Instance.PlayerMp < 0.9f)
        {
            color.material.color = Color.white;
        }




        





    }

    //�÷��̾� �� �׶��尡 ������ ����ī��Ʈ�� ����
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Ground")
        {
            
            jumpCount = 0;
        }
    }
    //�÷��̾ �������� ���� die�Լ� ȣ�� 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Dead")
        {
            Die();
            
        }

    }
    //���ӻ��¸� �ٲ� �Լ��� �ҷ����� �÷��̾ ����
    void Die()
    {
        
        playerRigidbody.velocity = Vector2.zero;
        GameManager.Instance.Die(); 
        gameObject.SetActive(false);
    }





}
