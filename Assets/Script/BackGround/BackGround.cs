using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.isgameOver == true) return;

        transform.Translate(Vector2.left*10f*Time.deltaTime);
    }
}
