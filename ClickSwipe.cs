using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make sure the types are on the gameObj the script is attached to
[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;
    private bool swiping = false;

    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                updateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                updateComponents();
            }
            if (swiping)
            {
                updateMousePos();
            }
        }
    }

    void updateMousePos()
    {
        //convert screen pos of the mouse to a world pos
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = mousePos;
    }

    void updateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }



}
