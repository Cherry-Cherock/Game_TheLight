using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private KuLouFSM manager;
    private Parameter parameter;

    private float timer;
    public IdleState(KuLouFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Idle");
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;
        //
        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (parameter.target != null &&
            parameter.target.position.x >= parameter.chasePoints[0].position.x &&
            parameter.target.position.x <= parameter.chasePoints[1].position.x)
        {
            manager.TransitionState(StateType.React);
        }
        if (timer >= parameter.idleTime)
        {
            manager.TransitionState(StateType.Patrol);
        }
    }

    public void OnExit()
    {
        // timer = 0;
    }
}

public class PatrolState : State
{
    private KuLouFSM manager;
    private Parameter parameter;

    private int patrolPosition;
    public PatrolState(KuLouFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Walk");
    }

    public void OnUpdate()
    {
        manager.FlipTo(parameter.patrolPoints[patrolPosition]);

        manager.transform.position = Vector3.MoveTowards(manager.transform.position,
            parameter.patrolPoints[patrolPosition].position, parameter.moveSpeed * Time.deltaTime);

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (parameter.target != null &&
            parameter.target.position.x >= parameter.chasePoints[0].position.x &&
            parameter.target.position.x <= parameter.chasePoints[1].position.x)
        {
            manager.TransitionState(StateType.React);
        }
        if (Vector3.Distance(manager.transform.position, parameter.patrolPoints[patrolPosition].position) < .1f)
        {
            manager.TransitionState(StateType.Idle);
        }
    }

    public void OnExit()
    {
        patrolPosition++;

        if (patrolPosition >= parameter.patrolPoints.Length)
        {
            patrolPosition = 0;
        }
    }
}

public class ChaseState : State
{
    private KuLouFSM manager;
    private Parameter parameter;

    public ChaseState(KuLouFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Walk");
    }

    public void OnUpdate()
    {
        manager.FlipTo(parameter.target);
        if (parameter.target)
            manager.transform.position = Vector3.MoveTowards(manager.transform.position,
            parameter.target.position, parameter.chaseSpeed * Time.deltaTime);

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (parameter.target == null ||
            manager.transform.position.x < parameter.chasePoints[0].position.x ||
            manager.transform.position.x > parameter.chasePoints[1].position.x)
        {
            manager.TransitionState(StateType.Idle);
        }
        if (Physics.OverlapSphere(parameter.attackPoint.position, parameter.attackArea, parameter.targetLayer).Length>0)
        {
            if (Math.Abs(manager.transform.position.z - parameter.target.position.z) < 0.1)
            {
               manager.TransitionState(StateType.Attack); 
            }
            Vector3 backPos = new Vector3(parameter.curDir ? manager.transform.position.x+0.8f :manager.transform.position.x-0.8f ,manager.transform.position.y,manager.transform.position.z);
            manager.transform.position = Vector3.MoveTowards(manager.transform.position, backPos, parameter.chaseSpeed * Time.deltaTime);
        }
    }

    public void OnExit()
    {

    }
}

public class ReactState : State
{
    private KuLouFSM manager;
    private Parameter parameter;

    private AnimatorStateInfo info;
    public ReactState(KuLouFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("React");
    }

    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (info.normalizedTime >= .95f)
        {
            manager.TransitionState(StateType.Chase);
        }
    }

    public void OnExit()
    {

    }
}

public class AttackState : State
{
    private KuLouFSM manager;
    private Parameter parameter;

    private AnimatorStateInfo info;
    public AttackState(KuLouFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Attack");
    }

    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);

        if (parameter.getHit)
        {
            manager.TransitionState(StateType.Hit);
        }
        if (info.normalizedTime >= .95f)
        {
            manager.TransitionState(StateType.Chase);
        }
    }

    public void OnExit()
    {

    }
}

public class HitState : State
{
    private KuLouFSM manager;
    private Parameter parameter;

    private AnimatorStateInfo info;
    public HitState(KuLouFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.SetBool("isHit",true);
        parameter.health--;
    }

    public void OnUpdate()
    {
        // info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        //
        if (parameter.health <= 0)
        {
            manager.TransitionState(StateType.Death);
        }
        // if (info.normalizedTime >= .95f)
        // {
        //     parameter.target = GameObject.FindWithTag("Player").transform;
        //
        //     manager.TransitionState(StateType.Chase);
        // }
    }

    public void OnExit()
    {
        parameter.getHit = false;
    }
}

public class DeathState : State
{
    private KuLouFSM manager;
    private Parameter parameter;

    public DeathState(KuLouFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.SetBool("isDeath",true);
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}
