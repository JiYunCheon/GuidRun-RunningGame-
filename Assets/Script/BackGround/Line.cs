using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lr;
    Vector3 plat, Sorcerer;

  
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = .05f;
        lr.endWidth = .05f;

        plat = gameObject.GetComponent<Transform>().position;


    }

    void Update()
    {
        lr.SetPosition(0, plat);
        lr.SetPosition(1, GameObject.Find("F").GetComponent<Transform>().position);

    }
}
