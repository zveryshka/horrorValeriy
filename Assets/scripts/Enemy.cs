using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    private NavMeshAgent agent;

    [Header("Vision")]
    public float viewDistance = 15f;
    public float viewAngle = 90f;
    public LayerMask obstacleMask;

    [Header("Patrol")]
    public float patrolRadius = 20f;
    public float patrolWaitTime = 2f;

    private bool chasingPlayer;
    private float waitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToRandomPoint();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            chasingPlayer = true;
            agent.SetDestination(player.position);
        }
        else
        {
            if (chasingPlayer)
            {
                chasingPlayer = false;
                GoToRandomPoint();
            }

            if (!agent.pathPending && agent.remainingDistance < 1f)
            {
                waitTimer += Time.deltaTime;

                if (waitTimer >= patrolWaitTime)
                {
                    GoToRandomPoint();
                    waitTimer = 0f;
                }
            }
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer =
            (player.position - transform.position).normalized;

        float distance =
            Vector3.Distance(transform.position, player.position);

        if (distance > viewDistance)
            return false;

        float angle =
            Vector3.Angle(transform.forward, directionToPlayer);

        if (angle > viewAngle / 2)
            return false;

        if (Physics.Raycast(
            transform.position + Vector3.up,
            directionToPlayer,
            distance,
            obstacleMask))
        {
            return false;
        }

        return true;
    }

    void GoToRandomPoint()
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = new Vector3(
                Random.Range(-50f, 50f),
                0,
                Random.Range(-50f, 50f)
            );

            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 5f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewDistance);
    }
}