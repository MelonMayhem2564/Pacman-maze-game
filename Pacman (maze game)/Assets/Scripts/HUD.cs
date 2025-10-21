using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public int lives;
    public int points;
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI pointsUI;
    public int currentLives;
    public int currentPoints;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        lives = currentLives;
        points = currentPoints;
        player = GameObject.Find("Chomp");
        healthUI.text = lives.ToString();
        pointsUI.text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayLives();
        DisplayPoints();
    }

    void DisplayLives()
    {
        print("Lives = " + player.GetComponent<PlayerScript>().GetLives());
        healthUI.text = "Lives : " + player.GetComponent<PlayerScript>().GetLives();
    }

    void DisplayPoints()
    {
        print("Points = " + player.GetComponent<PlayerScript>().GetPoints());
        pointsUI.text = "Points : " + player.GetComponent<PlayerScript>().GetPoints();
    }
}
