using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatManager : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private float movementCounter;
    private float movementCounterMax;
    public bool escaping;
    public Vector2 velocityPrime;
    public Collider2D player;
    private Vector2 collisionPoint;
    private float speed;
    private float initialSpeed = 5f;
    GameObject ray;
    RaycastHit2D hit;

    public Dictionary<string, bool> worldState = new Dictionary<string, bool>();

    void Start()
    {
        movementCounterMax = 2;
        myRigidBody = GetComponent<Rigidbody2D>();
        movementCounter = movementCounterMax;
        speed = initialSpeed;
        ray = transform.GetChild(0).gameObject;

        worldState.Add("Day", false);
        worldState.Add("CloserThan6", false);
        worldState.Add("CloserThan5", false);
    }

    private void FixedUpdate()
    {
        List<string> keyList = new List<string>(worldState.Keys);
        for (int i = 0; i < keyList.Count; i++)
        {
            Debug.Log(keyList[i] + worldState[keyList[i]]);
        }
    }

    public void CheckWorld()
    {

    }

    public void CheckForward()
    {
        Vector3 direction = ray.transform.position - transform.position;
        hit = Physics2D.Raycast(ray.transform.position, direction, 1, LayerMask.GetMask("Wall"));
        if (hit)
        {
            var angle = Vector2.Angle(-ray.transform.position, hit.normal);
            Vector2 rotatedVector = Quaternion.Euler(0, 0, angle) * myRigidBody.velocity;
            Vector2 target = rotatedVector - (Vector2)transform.position;
            MoveTowards(-target);
            myRigidBody.velocity = target;

            //Debug.DrawLine(ray.transform.position, hit.point, Color.red);
            //Debug.DrawLine(hit.point, rotatedVector, Color.blue);
            //Debug.DrawLine(hit.point, hit.normal,Color.green);
        }
    }

    public void Escape()
    {
        CheckForward();
        myRigidBody.velocity = new Vector2(0,0);
        MoveTowards(player.transform.position - transform.position);
        myRigidBody.transform.Translate(Vector2.down * Time.deltaTime * speed);
        speed += Time.deltaTime;
    }

    public void Wander()
    {
        CheckForward();
        if (speed > initialSpeed)
        {
            speed = initialSpeed;
        }
        if (movementCounter > 0)
        {
            movementCounter -= Time.deltaTime * 3f;
        }
        if (movementCounter <= 0)
        {
            ChangeVelocity();
            movementCounter = movementCounterMax;
        }
    }

    public void ChangeVelocity()
    {
        float moveX = UnityEngine.Random.Range(-1f, 1f);
        float moveY = UnityEngine.Random.Range(-1f, 1f);
        Vector2 moveVector = new Vector2(moveX * 10, moveY * 10);
        MoveTowards(- moveVector);
        myRigidBody.velocity = moveVector;
    }


    public void MoveTowards(Vector2 targetVector)
    {
        Vector3 diff = targetVector;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}

