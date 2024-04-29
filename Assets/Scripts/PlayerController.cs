using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    float vertical;
    float horizontal;

    public float speed;

    public int pickUpLimit = 1;
    public int pickUpCount = 0;
    public bool canPickUp = true;

    public int score;
    public int health;

    public TMP_Text scoreText;
    public TMP_Text healthText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pickUpCount = 0;
        DeathMenu.isDead = false;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(horizontal, vertical);
        rb.velocity = input.normalized * speed;

        if (pickUpCount == pickUpLimit){
            canPickUp = false;
        } else {
            canPickUp = true;
        }

        if(health <= 0){
            DeathMenu.isDead = true;
        }
        scoreText.text = score.ToString();
        healthText.text = health.ToString();
    }
}