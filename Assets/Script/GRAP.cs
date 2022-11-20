using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRAP : MonoBehaviour
{

    Hook grap;
    DistanceJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        grap = FindObjectOfType<Hook>();
        joint = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ring"))
        {
            joint.enabled = true;
            grap.attach = true;
        }
    }

}
