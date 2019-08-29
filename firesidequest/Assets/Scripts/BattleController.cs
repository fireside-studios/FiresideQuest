using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool triggerAttack = false;

    public UnityEngine.UI.Button[] objs;

    public BaseHuman playerChar;
    public BaseHuman enemyChar;

    private BaseHuman aggressor;
    private BaseHuman defendor;

    private float aggressorSTR;
    private float defendorCurHP;
    private float defendorDEF;

    [SerializeField] private HealthBar healthBar;
    void Start()
    {
        startPos = player.transform.position;

        foreach (UnityEngine.UI.Button btn in objs)
        {
            btn.onClick.AddListener(() => { triggerAttack = true; });
        }

        aggressor = playerChar.GetComponent<BaseHuman>();
        defendor = enemyChar.GetComponent<BaseHuman>();
        aggressorSTR = aggressor.STR;
        defendorCurHP = defendor.curHP;
        defendorDEF = defendor.DEF;


    }

    void FixedUpdate()
    {
        if (triggerAttack == true && isAttacking == false && isReturning == false) {
            triggerAttack = false;
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
        }
    }

    public void AttackMovement(Vector3 start, Vector3 target)
    {

        if (currentLerpTime >= 1.0f)
        {
            currentLerpTime = 0f;
            isAttacking = false;
            isReturning = true;
            defendorCurHP -= (aggressorSTR - defendorDEF);
            defendor.curHP = defendorCurHP;
            healthBar.SetSize(defendorCurHP / defendor.baseHP);
        }

        if (isAttacking)
        {
            currentLerpTime += (Time.deltaTime);
            float perc = currentLerpTime / 1.0f;
            player.transform.position = Vector3.Lerp(start, target, perc);
        }
    }

    public void ReturnToStart(Vector3 start, Vector3 target)
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
