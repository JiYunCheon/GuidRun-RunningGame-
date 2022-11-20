using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float totalTime;
    GroundSpawner gs;
    Vector3 v;
    public GameObject Monster;
    

    float Ran;

    private void Awake()
    {
        v = transform.position;
    }

    private void OnEnable()
    {
        transform.position = new Vector3(30,0);
        this.Ran = Random.Range(0, 3);
        FindObjectOfType<GroundSpawner>().Ran= this.Ran;

        if(Random.Range(0, 2) == 0)
        {
            Monster.SetActive(true);
        }
        else
        {
            Monster.SetActive(false);
        }
        
    }

    void Start()
    {
        gs = FindObjectOfType<GroundSpawner>();
        totalTime = 0;
    }

    void Update()
    {
        if (GameManager.Instance.isgameOver == true) return;

        totalTime += Time.deltaTime;
        if (totalTime > 8f)
        {
            totalTime = 0;
            gs.SendMessage("Release", this, SendMessageOptions.RequireReceiver);
        }



    }
}
