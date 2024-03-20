using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ZombieController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator animator = null;
    private ZombieStats stats = null;
    private Transform target;
    [SerializeField]private float stoppingDistance;
    [SerializeField] private float timeOfLastAttack = 0;
    private bool hasStopped = false;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        animator.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        RotateToTarget();

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
            //attack
            if (!hasStopped)
            {
                hasStopped = true;
                timeOfLastAttack = Time.time;
            }
            if (Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                Stats_Character targetStats = target.GetComponent<Stats_Character>();
                AttackTarget(targetStats);
            }
        }
        else
        {
            if (hasStopped)
            {
                hasStopped = false;
            }
        }
    }

    private void RotateToTarget()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void AttackTarget(Stats_Character statsToDamage)
    {
        animator.SetTrigger("attack");
        // mettre un truc pour attendre si quelqu'un sait faire
        stats.DealDamage(statsToDamage);
    }




    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        stats = GetComponent<ZombieStats>();
        target = PlayerShoot.instance;
    }
}
