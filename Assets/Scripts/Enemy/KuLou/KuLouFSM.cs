using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateType
{
    Idle,
    Patrol,
    Chase, 
    React,
    Attack,
    Hit,
    Death
}
[Serializable]
public class Parameter
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;
    public float attackArea;
    public Animator animator;
    public bool getHit;
    //right = 1; left = 0;
    public bool curDir;
    public GameObject floatPoint;
}
    
public class KuLouFSM: MonoBehaviour
{
    private State currentState;
    private Dictionary<StateType, State> states = new Dictionary<StateType, State>();

    public Parameter parameter;

    private void OnEnable()
    {
        ProjectAttack.hitE += getHit;
    }

    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.Hit, new HitState(this));
        states.Add(StateType.Death, new DeathState(this));

        TransitionState(StateType.Idle);

        parameter.animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                parameter.curDir = true;
            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                parameter.curDir = false;
            }
        }
    }

    public void ShowFloatPoint()
    {
      GameObject go =  Instantiate(parameter.floatPoint, transform.position, Quaternion.identity) as GameObject;
      go.transform.GetChild(0).GetComponent<TextMesh>().text = PlayerController.GetCurrentDamage().ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }

    public void getHit()
    {
        parameter.getHit = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
    }
}