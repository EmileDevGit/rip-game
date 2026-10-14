using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;
    public string playerID;
    [SerializeField] Transform _player;

    [Header("Layers Identifiers")]
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patroling")]
    public Transform[] points;
    [SerializeField] Vector3 _walkPoint;
    [SerializeField] int _destinationIndex;

    [Header("States")]
    public float sightRange, interactTime;
    [SerializeField] float _talkTimeRemaning;
    [SerializeField] bool _playerInSightRange, _isInteracting;

    private bool shouldPausePatrol = false; 

    

    void Start()
    {
        _destinationIndex = FindClosestDestination();
        _player = GameObject.Find(playerID).transform;
        agent = GetComponent<NavMeshAgent>();
        _talkTimeRemaning = interactTime;
    }

    void Update()
    {
        _playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        // Update interaction state
        if (_playerInSightRange || _isInteracting)
        {
            StopWalking(); // Pause movement
            TalkToPlayer();
        }
        else
        {
            ResumeWalking();
            WalkAround();
        }
    }

    void WalkAround()
    {
        SetDestination(points[_destinationIndex]);

        float _distance = agent.remainingDistance;

        if (_distance <= 0.5f)
        {
            _destinationIndex = (_destinationIndex + 1) % points.Length;
            SetDestination(points[_destinationIndex]);
        }
    }

    void TalkToPlayer()
    {
        _isInteracting = true;
        _talkTimeRemaning -= Time.deltaTime;

        if (_talkTimeRemaning <= 0f)
        {
            _isInteracting = false;
            _talkTimeRemaning = interactTime;
        }
    }

    void SetDestination(Transform destination)
    {
        if (CanReachDestination(destination))
        {
            _walkPoint = new Vector3(destination.position.x, transform.position.y, destination.position.z);
            agent.destination = _walkPoint;
        }
    }

    bool CanReachDestination(Transform destination)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(new Vector3(destination.position.x, transform.position.y, destination.position.z), path);
        return path.status != NavMeshPathStatus.PathPartial;
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

    public void StopWalking()
    {
        shouldPausePatrol = true;
        if (agent.enabled && agent.isActiveAndEnabled)
        {
            agent.isStopped = true;
        }
    }

    public void ResumeWalking()
    {
        shouldPausePatrol = false;
        if (agent.enabled && agent.isActiveAndEnabled)
        {
            agent.isStopped = false;
        }
    }

    public void TriggerInteraction()
    {
        StopWalking(); // Call this from Interact
        _isInteracting = true;
        _talkTimeRemaning = interactTime;
    }
}
