using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(a.PlayerTag))
        {
            Debug.Log("hello");
            GameObject.Find("GameManager").GetComponent<GameManager>()._EndLvl();
        }   
    }

    void Update()
    {
        
    }
}
