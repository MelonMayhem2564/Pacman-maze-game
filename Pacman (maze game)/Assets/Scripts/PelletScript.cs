using UnityEngine;

public class PelletScript : MonoBehaviour
{
    public int currentPoints;
    public int pelletPoints = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetPoints();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pellet")
        {
            Destroy(collision.gameObject);
            currentPoints = currentPoints + pelletPoints;
        }
    }

    public int GetPoints()
    {
        return currentPoints;
    }
}
