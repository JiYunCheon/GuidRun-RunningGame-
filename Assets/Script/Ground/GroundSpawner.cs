using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : ObjectPool<Ground>
{
    public Ground groundprefab;
    
    public GameObject Monster;

    public float totalTime;

    public float Ran;

    public bool spawn=false;

    public override Ground CreatePool()
    {
        return groundprefab;
    }
   
    void Start()
    {
        Pool_Max_Size = 10;
    }

    void Update()
    {
        if (GameManager.Instance.isgameOver == true) return;
        totalTime += Time.deltaTime;
        
        if (Ran==0)
        {
            
            if (totalTime > 3f)
            {
                spawn = true;
                totalTime = 0;
                Get();
            }
        }
        else
        {
            if (totalTime > 1f)
            {
                spawn=false;
                totalTime = 0;
                Get();
            }
        }
        

    }
}
