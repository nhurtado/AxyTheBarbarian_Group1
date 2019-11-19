using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatManager : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private float movementCounter;
    private float movementCounterMax;
    public Collider2D player;
    private float speed;
    public float initialSpeed = 3.5f;
    GameObject ray;
    RaycastHit2D hit;
    DayNightCycle dayNightCycle;
    Node decisionTree;

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

        GameObject observer = GameObject.Find("Observer");
        dayNightCycle = observer.GetComponent<DayNightCycle>();

        ActionNode wanderNode = new ActionNode();
        wanderNode.actionMethod = Wander;

        ActionNode attackNode = new ActionNode();
        attackNode.actionMethod = Attack;

        ActionNode escapeNode = new ActionNode();
        escapeNode.actionMethod = Escape;

        BinaryNode attackDecisionNode = new BinaryNode();
        attackDecisionNode.yesNode = attackNode;
        attackDecisionNode.noNode = wanderNode;
        attackDecisionNode.decision = "CloserThan6";

        BinaryNode escapeDecisionNode = new BinaryNode();
        escapeDecisionNode.yesNode = escapeNode;
        escapeDecisionNode.noNode = wanderNode;
        escapeDecisionNode.decision = "CloserThan5";

        BinaryNode dayNightNode = new BinaryNode();
        dayNightNode.yesNode = attackDecisionNode;
        dayNightNode.noNode = escapeDecisionNode;
        dayNightNode.decision = "Day";

        decisionTree = dayNightNode;
    }

    private void FixedUpdate()
    {
        CheckWorld();
        decisionTree.Decide(worldState);
    }

    public void CheckWorld()
    {
        worldState["Day"] = dayNightCycle.day;
    }

    public void CheckForward()
    {
        Vector3 direction = ray.transform.position - transform.position;
        Debug.DrawRay(ray.transform.position,  direction);
        hit = Physics2D.Raycast(ray.transform.position, direction, 0.6f, LayerMask.GetMask("Wall", "Enemy"));
        if (hit)
        {
            Debug.DrawRay(ray.transform.position, hit.point -(Vector2)ray.transform.position, Color.red);
            Vector2 reflecVec = Vector2.Reflect(hit.point - (Vector2)ray.transform.position, hit.normal);
            float originalMagnitude = myRigidBody.velocity.magnitude;
            if (originalMagnitude < 0.3)
            {
                originalMagnitude = 0.4f;
            }
            Debug.DrawRay(hit.point, reflecVec, Color.blue);
            myRigidBody.velocity = reflecVec.normalized * originalMagnitude;
            MoveTowards(-reflecVec);
        }
    }

    public void Escape()
    {
        CheckForward();
        MoveTowards(player.transform.position - transform.position);
        myRigidBody.velocity = (transform.position - player.transform.position)*speed;
        speed += Time.deltaTime;
    }

    public void Attack()
    {
        CheckForward();
        MoveTowards(-(player.transform.position - transform.position));
        myRigidBody.velocity = (player.transform.position - transform.position) * speed/5;
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
            movementCounter -= Time.deltaTime * 2f;
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
        Vector2 moveVector = new Vector2(moveX * 4, moveY * 4);
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

