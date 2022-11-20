using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;
    BoxCollider2D backGroundCollider;
    private void Awake()
    {
        backGroundCollider=GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x; 
    }
    
    void Update()
    {
        if (GameManager.Instance.isgameOver == true) return;

        if (transform.position.x<=-width)
        {
            Reposition();
        }
        
    }
    void Reposition()
    {
        Vector3 offset = new Vector3(width * 2f, 0);
        transform.position += offset;
    }

}
