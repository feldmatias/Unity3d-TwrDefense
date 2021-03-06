﻿using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 0.8f;
    public float waypointDistanceOffset = 0.5f;
    public bool enemyFlies = false;

    private int waypointIndex;
    private Rigidbody rigidBody;

    private float slowDownMultiplier;
    private float slowDownTimer;

    private bool isEnabled = true;

    public float ProgressToPlayerBase { get; private set; }

    public void Enable()
    {
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        isEnabled = true;

        waypointIndex = enemyFlies ? EnemyManager.Instance.GetLastWaypointIndex() : 0;
        rigidBody.detectCollisions = true;
        rigidBody.useGravity = !enemyFlies;

        slowDownMultiplier = 1;
        slowDownTimer = 0;
    }

    public void Disable()
    {
        isEnabled = false;

        rigidBody.velocity = Vector3.zero;
        rigidBody.detectCollisions = false;
        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled)
        {
            return;
        }

        CheckWaypoint();
        SetRotation();
        SetVelocity();
    }

    private void CheckWaypoint()
    {
        var distanceToWaypoint = Vector3.Distance(transform.position, EnemyManager.GetWaypoint(waypointIndex).position);

        SetProgressToPlayerBase(distanceToWaypoint);

        if (distanceToWaypoint <= waypointDistanceOffset)
        {
            waypointIndex++;
        }
    }

    private void SetRotation()
    {
        var forwardDir = (EnemyManager.GetWaypoint(waypointIndex).position - transform.position);
        forwardDir.y = 0;
        transform.forward = Vector3.Lerp(transform.forward, forwardDir, rotationSpeed * Time.deltaTime);
    }

    private void SetVelocity()
    {
        slowDownTimer -= Time.deltaTime;
        if (slowDownTimer <= 0)
        {
            slowDownMultiplier = 1;
        }

        var velocity = transform.forward * speed * slowDownMultiplier;
        velocity.y = rigidBody.velocity.y;
        rigidBody.velocity = velocity;
    }

    private void SetProgressToPlayerBase(float distanceToWaypoint)
    {
        ProgressToPlayerBase = (waypointIndex + 1) * 1000 - distanceToWaypoint * 2;
    }

    public void SetWaypoint(EnemyMovement other)
    {
        waypointIndex = other.waypointIndex;
    }

    public void SlowDown(float multiplier, float duration)
    {
        slowDownMultiplier = multiplier;
        slowDownTimer = duration;
    }
}
