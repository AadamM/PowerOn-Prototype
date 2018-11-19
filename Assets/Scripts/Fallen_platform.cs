using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallen_platform : MonoBehaviour
{

    Rigidbody2D rb;
    public string player_name = "Player";
    public float time_before_fallen = 1.5f;
    public float time_before_destroy = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == player_name)
        {
            Invoke("fallen_branch", time_before_fallen);
        }
    }

    void fallen_branch()
    {
        rb.isKinematic = false;
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        Invoke("destory_branch", time_before_destroy);
        return;
    }

    void destory_branch()
    {
        Destroy(gameObject);
        return;
    }

}

