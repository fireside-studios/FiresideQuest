using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{

    public Transform player;
    public Transform enemy;
    public float speed = 1.0f;

    private Vector3 startPos;
    private float currentLerpTime;
    private float returnLerpTime;
    private bool isAttacking = false;
    private bool isReturning = false;


    void Start()
    {
        startPos = player.transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space") && isAttacking == false && isReturning == false) {
            currentLerpTime = 0f;
            returnLerpTime = 0f;
            isAttacking = true;
        }

        if (isAttacking)
        {
            AttackMovement(startPos, enemy.transform.position);
        }

        if (isReturning) {
            ReturnToStart(player.transform.position, startPos);
            //Debug.Log(isReturning);
        }
        

    }

    void AttackMovement(Vector3 start, Vector3 target)
    {

        if (currentLerpTime >= 1.0f)
        {
            currentLerpTime = 0f;
            isAttacking = false;
            isReturning = true;
        }

        if (isAttacking)
        {
            currentLerpTime += (Time.deltaTime);
            float perc = currentLerpTime / 1.0f;
            player.transform.position = Vector3.Lerp(start, target, perc);
        }
    }

    void ReturnToStart(Vector3 start, Vector3 target)
    {
        if (returnLerpTime >= 1.0f)
        {
            returnLerpTime = 1.0f;
            
            isReturning = false;
        }

        if (isReturning)
        {
            returnLerpTime += (Time.deltaTime);
            float perc = returnLerpTime / 1.0f;
            player.transform.position = Vector3.Lerp(start, target, perc);
        }
    }

}
