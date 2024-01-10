using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

    public ParticleSystem explosion;

    private float maxSpeed = 16;
    private float minSpeed = 12;
    private float torq = 10;
    private float xRange = 4;

    public int value;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        rb.AddForce(randomForce(), ForceMode.Impulse);
        rb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = spawnPos(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameManager.gameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameManager.updateScore(value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //destroy on bounds
        Destroy(gameObject);
        if(!gameObject.CompareTag("bad"))
        {
            if (gameManager.lives > 0)
            {
                gameManager.lives--;
                gameManager.livesText.text = "Lives: " + gameManager.lives;
            }
            else
            {
                gameManager.gameIsOver();
            }
        }
    }

    public void DestroyTarget()
    {
        if (gameManager.gameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gameManager.updateScore(value);
        }
    }
    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float randomTorque()
    {
        return Random.Range(-torq, torq);
    }

    Vector3 spawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -2);
    }

   
}
