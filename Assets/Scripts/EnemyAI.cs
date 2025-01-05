using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class EnemyAI : MonoBehaviour
    {
        NavMeshAgent agent;

        Transform player;
        [SerializeField] LayerMask whatIsPlayer;
        [SerializeField] LayerMask whatIsGround;

        //Patrolling
        public Vector3 walkPoint;
        bool walkPointSet = false;
        public float walkPointRange;

        //Attacking
        public float timeBetweenAttacks;
        bool alreadyAttacked;

        //States
        public float sightRange;
        public float attackRange;
        public bool playerInSightRange;
        public bool playerInAttackRange;

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
            Debug.Log(walkPointSet);
            if (!playerInSightRange && !playerInAttackRange) Patrolling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && playerInAttackRange) AttackPlayer();
        }

        void Patrolling()
        {
            if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet) agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }

        void SearchWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);
            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
            if (Physics.Raycast(walkPoint, -transform.up, out RaycastHit hitInfo, 2f, whatIsGround))
            {
                Debug.Log(hitInfo.point);
                walkPointSet = true;
            }
            // Plane plane = new Plane(Vector3.up, Vector3.zero);
            // Ray ray = new Ray(walkPoint, -transform.up);
            // if (plane.Raycast(ray, out float distance))
            // {
            //     walkPointSet = true;
            // }
        }

        void ChasePlayer()
        {
            agent.SetDestination(player.transform.position);
        }

        void AttackPlayer()
        {
            agent.SetDestination(agent.transform.position);

            transform.LookAt(player);

            if (!alreadyAttacked)
            {

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }

        void ResetAttack()
        {
            alreadyAttacked = false;
        }

    }
}
