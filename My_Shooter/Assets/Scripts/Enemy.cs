using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Player player;
    private Rigidbody2D enemyrb;
    void Start()
    {
        enemyrb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed * Time.deltaTime);
    }
}
