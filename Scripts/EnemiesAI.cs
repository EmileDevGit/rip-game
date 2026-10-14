using Controller;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesAI : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;
    public Transform _player;

    [Header("Layers Identifiers")]
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patroling")]
    public Transform[] points;
    private Vector3 _walkPoint;
    [SerializeField] int _destinationIndex;

    [Header("States")]
    public float sightRange, attackRange;
    private bool _playerInSightRange, _playerInAttackRange, _isChasing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _destinationIndex = FindClosestDestination();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (CanReachDestination(_player))
        {
            if (!_playerInSightRange && !_playerInAttackRange)
                Patrol();

            if (_playerInSightRange && !_playerInAttackRange)
                Chase();

            if (_playerInSightRange && _playerInAttackRange)
                Attack();
        }
        else Patrol();

    }

    #region Actions
    void Patrol()
    {
        if (_isChasing) _destinationIndex = FindClosestDestination();
        
        _isChasing = false;

        SetDestination(points[_destinationIndex]);

        float _distance = agent.remainingDistance;

        if (_distance <= 0.5f)
        {
            if (_destinationIndex < points.Length - 1) _destinationIndex++;
            else _destinationIndex = 0;

            SetDestination(points[_destinationIndex]);
        }
    }

    void Chase()
    {
        if (CanReachDestination(_player))
        {
            _isChasing = true;
            SetDestination(_player.transform);
        }
        else _destinationIndex = FindClosestDestination();
    }

    void Attack()
    {

    }

    #endregion

    #region Destinations Manager
    void SetDestination(Transform destination)
    {
        if (CanReachDestination(destination))
        {
            _walkPoint = new Vector3(destination.position.x, transform.position.y, destination.position.z);
            agent.destination = _walkPoint;
        }
    }

    int FindClosestDestination()
    {
        int _closestDestination = 0;

        for (int i = 0; i < points.Length - 1; i++)
        {
            float distance = Vector3.Distance(transform.position, points[i].position);
            if (distance < Vector3.Distance(transform.position, points[_closestDestination].position))
                _closestDestination = i;
        }
        return _closestDestination;
    }

    bool CanReachDestination(Transform destination)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(new Vector3(destination.position.x, transform.position.y, destination.position.z), path);
        
        if (path.status != NavMeshPathStatus.PathPartial) return true;
        else return false;
    }

    #endregion
}
