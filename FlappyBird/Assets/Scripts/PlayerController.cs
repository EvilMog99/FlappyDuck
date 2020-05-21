using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxTimeTillJump = 1.5f;
    private float timeTillCanJump = 0f;

    Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
        timeTillCanJump = MaxTimeTillJump;//Allow to jump from the very start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && timeTillCanJump >= MaxTimeTillJump)
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
        Debug.Log("Hit player");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            Debug.Log("Player Collider");
            hitObstacle(gameObject.tag);
        }
    }

    private void OnTriggerStay(Collider collider)
    {

    }

    private void OnTriggerExit(Collider collider)
    {

    }
}
