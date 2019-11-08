using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatManager : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private float movementCounter;
    private float movementCounterMax;
    private bool escaping;
    private Collider2D player;

    // Start is called before the first frame update
    void Start()
    {
        movementCounterMax = 2;
        myRigidBody = GetComponent<Rigidbody2D>();
        movementCounter = movementCounterMax;
        //changeVelocity();
    }

    // Update is called once per frame
    void Update()
    {


        if (escaping)
        {
            Vector2 velocityPrime = new Vector2(player.transform.position.x - myRigidBody.gameObject.transform.position.x, player.transform.position.y - myRigidBody.gameObject.transform.position.x); ;
            myRigidBody.velocity = velocityPrime.normalized;
        }
        else
        {
            if (movementCounter > 0)
            {
                movementCounter -= Time.deltaTime;
            }

            if (movementCounter <= 0)
            {
                changeVelocity();
                movementCounter = movementCounterMax;
            }
        }
    }

    public void changeVelocity()
    {
        float moveX = Random.Range(-1f, 1f);
        float moveY = Random.Range(-1f, 1f);
        myRigidBody.velocity = new Vector2(moveX * 3, moveY * 3);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other;
            escaping = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            escaping = false;
            player = null;
        }
    }
}