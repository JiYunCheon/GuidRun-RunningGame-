using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public float AttackSpeed = 10f;
    public Sorcerer sorcerer;
    public Archor archor;


    public Renderer color;
    public Transform Tr;


    public SpriteRenderer sr;
    public BoxCollider2D bc;



    public bool socerer_Skill_Attack=false;
    public bool arhor_Skill_Attack=false;

    public float totalTime = 0;
    public float skill_Time = 0;





    private void Awake()
    {
        color = GetComponent<Renderer>();
    }


    private void Start()
    {
        sorcerer = FindObjectOfType<Sorcerer>();
        archor = FindObjectOfType<Archor>();

       
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();


        if (DataManager.instance.CurrentCharacter == Character.Sorcerer)
        socerer_Skill_Attack = FindObjectOfType<Sorcerer>().Sorcerer_Skill;

        if (DataManager.instance.CurrentCharacter == Character.Archor)
            arhor_Skill_Attack = FindObjectOfType<Archor>().Archor_Skill;
    }

    private void Update()
    {
        
    }


    public void Sorcerer_Attack_false(Sorcerer sorcerer)
    {
        sorcerer.SendMessage("Release", this, SendMessageOptions.RequireReceiver);
    }

    public void Archor_Attack_false(Archor archor)
    {
        archor.SendMessage("Release", this, SendMessageOptions.RequireReceiver);
    }

    public void Attack_Speed(float speed)
    {
        transform.Translate(Vector3.right * AttackSpeed * Time.deltaTime*speed);
    }

}
