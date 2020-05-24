using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxTimeTillJump = 1.5f;
    private float timeTillCanJump = 0f;
    private bool gameRunning = true;

    Rigidbody rig;
    MenuEvents menuEventsScript;
    public GameObject endGamePanel;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        if (endGamePanel == null) Debug.Log("Failed to load menu!");
        menuEventsScript = GameObject.Find("Canvas").GetComponent<MenuEvents>();
        rig = gameObject.GetComponent<Rigidbody>();
        timeTillCanJump = MaxTimeTillJump;//Allow to jump from the very start
        menuEventsScript.togglePause(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && gameRunning && timeTillCanJump >= MaxTimeTillJump)
        {
            rig.velocity = new Vector3(rig.velocity.x, 10f, rig.velocity.z);
            timeTillCanJump = 0f;
        }

        if (timeTillCanJump < MaxTimeTillJump)
            timeTillCanJump += Time.deltaTime;
    }

    public void hitObstacle(string obstacleTag)
    {
        MaxTimeTillJump = 1000000f;
        gameRunning = false;
        Debug.Log("Hit player");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle" || collider.gameObject.tag == "Floor")
        {
            Debug.Log("Player Collider");
            hitObstacle(gameObject.tag);
        }

        if (collider.gameObject.tag == "Floor")
        {
            menuEventsScript.togglePause(true);
            menuEventsScript.SetGUIInvisibile(continueButton);
            menuEventsScript.OpenMenu(endGamePanel);
        }
    }

    private void OnTriggerStay(Collider collider)
    {

    }

    private void OnTriggerExit(Collider collider)
    {

    }
}
