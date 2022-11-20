using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //점프를 위해 리지드 바디 선언
    private Rigidbody2D playerRigidbody;

    //점프력 
    private float jump = 600f;
    //점프의 개수를 제한할 변수 
    private int jumpCount = 0;
    //플레이어 색깔 
    Renderer color;

   


    void Start()
    {
        //컴퍼넌트를 가져옴 
        playerRigidbody = GetComponent<Rigidbody2D>();
        color = GetComponent<Renderer>();
    }
    
    void Update()
    {
        //게임오버상태이면 리턴
        if (GameManager.Instance.isgameOver == true) return;

        //스페이스를 누르면 점프
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //점프 개수를 제한
            if(jumpCount <10)
            {
                jumpCount++;
                playerRigidbody.AddForce(transform.up * jump);
            }
        }
        //버튼에서 손을 때면 속도가 느려짐 
        else if(Input.GetKeyUp(KeyCode.Space)&& playerRigidbody.velocity.y>0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        //플레이어 마나가 꽉 찬경우 색깔을 바꿈
        if (GameManager.Instance.PlayerMp >= 0.9f)
        {
            color.material.color = Color.blue;
        }
        //마나가 꽉 찬경우가 아니라면 기본 색
        else if (GameManager.Instance.PlayerMp < 0.9f)
        {
            color.material.color = Color.white;
        }




        





    }

    //플레이어 와 그라운드가 만나면 점프카운트를 리셋
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Ground")
        {
            
            jumpCount = 0;
        }
    }
    //플레이어가 데드존에 들어가면 die함수 호출 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Dead")
        {
            Die();
            
        }

    }
    //게임상태를 바꿀 함수를 불러오고 플레이어를 없앰
    void Die()
    {
        
        playerRigidbody.velocity = Vector2.zero;
        GameManager.Instance.Die(); 
        gameObject.SetActive(false);
    }





}
