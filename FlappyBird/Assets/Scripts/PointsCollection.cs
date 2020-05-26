using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollection : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            //Increase score
            gameManager.addToScore(1);
        }
    }

    private void OnTriggerStay(Collider collider)
    {

    }

    private void OnTriggerExit(Collider collider)
    {

    }
}
