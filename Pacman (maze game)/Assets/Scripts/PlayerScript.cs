using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    SpriteRenderer sr;
    float speed = 3.5f;
    public GameObject Player;
    public int currentLives;
    public int maxLives = 3;
    public int currentPoints;
    public int pelletPoints = 10;
    public GameObject Spawn;
    public TextMeshProUGUI gameoverUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        currentLives = maxLives;
        currentPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        GetLives();
        GetPoints();
        ExitGame();
    }

    void Movement()
    {
        if ((Input.GetKey("up") == true) || (Input.GetKey("w") == true))
        {
            rb.linearVelocity = transform.forward * speed;
        }
        if ((Input.GetKey("down") == true) || (Input.GetKey("s") == true))
        {
            rb.linearVelocity = -transform.forward * speed;
        }
    }
    void Rotation()
    {
        if ((Input.GetKey("left") == true) || (Input.GetKey("a") == true))
        {
            transform.Rotate(0, -2f, 0, Space.Self);
        }
        if ((Input.GetKey("right") == true) || (Input.GetKey("d") == true))
        {
            transform.Rotate(0, 2f, 0, Space.Self);
        }
    }

    public void Death()
    {
        if (currentLives == 0)
        {
            gameoverUI.text = "GAME OVER!";
            Destroy(gameObject);
        }
    }

    public void Win()
    {
        if (currentPoints == 830)
        {
            gameoverUI.text = "GAME WIN!";
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentLives--;
            Death();
            Player.transform.position = Spawn.transform.position;
        }

        if (collision.gameObject.tag == "Pellet")
        {
            Destroy(collision.gameObject);
            currentPoints = currentPoints + pelletPoints;
        }
    }

    public int GetLives()
    {
        return currentLives;
    }

    public int GetPoints()
    {
        return currentPoints;
    }

    void ExitGame()
    {
        if (Input.GetKeyDown("Escape"))
        {
            Application.Quit();
        }
    }
}
