using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    bool spawn;
    private void OnEnable()
    {
     this.spawn = FindObjectOfType<GroundSpawner>().spawn;
       

        if(this.spawn==true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }


        
    }


}
