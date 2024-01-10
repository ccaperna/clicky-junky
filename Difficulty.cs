using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int diff;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        button.onClick.AddListener(setDiff);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDiff()
    {
        Debug.Log(gameObject.name + "was clicked");
        gameManager.startGame(diff);
    }
}
