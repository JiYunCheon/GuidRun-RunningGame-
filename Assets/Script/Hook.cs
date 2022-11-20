using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Vector2 mouseDir;

    public bool ishookActive;
    public bool Line_max;
    public bool attach;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth=0.5f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1,hook.position);
        line.useWorldSpace = true;
        attach = false;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);


        if (Input.GetKeyDown(KeyCode.E)&&ishookActive==false)
        {
            hook.position = transform.position;
            mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            ishookActive = true;
            hook.gameObject.SetActive(true);
        }
        if(ishookActive==true&& Line_max==false&& attach==false)
        {
            hook.Translate(mouseDir.normalized * Time.deltaTime * 15f);

            if (Vector2.Distance(transform.position, hook.position) > 8)
            {
                Line_max = true;
            }

        }
        else if(ishookActive == true && Line_max == true && attach == false)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15);
            if(Vector2.Distance(transform.position,hook.position)<0.1f)
            {
                ishookActive = false;
                Line_max = false;
                hook.gameObject.SetActive(false);
            }

        }
        else if (attach == true)
        {
            Vector2.Distance(transform.position, hook.position);
        }
       


    }
}
