using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent agent;
    public string playerID;
    [SerializeField] Transform _player;

    [Header("Layers Identifiers")]
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patroling")]
    [SerializeField] Vector3 _walkPoint;
    [SerializeField] float _walkPointRange;
    [SerializeField] bool _walkPointSet;

    [Header("States")]
    public float attackRange, attackPower, angerDuration, knockback, stuntTime;
    [SerializeField] int _playerHitCounter;
    [SerializeField] bool _playerInAttackRange, _isAngry, _isStunt;
    [SerializeField] float _angerTimeLeft, _stuntTimeLeft;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.Find(playerID).transform;
        agent = GetComponent<NavMeshAgent>();
        _playerHitCounter = 0;
        _angerTimeLeft = angerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        _playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (_playerHitCounter >= 5)
        {
            _isAngry = true;
        }
        else _isAngry = false;

        if (_isAngry)
            WantsThePlayerDead();
        else RunningAround();
    }

    void RunningAround()
    {
        if (!_walkPointSet) ThinkAboutNextDestination();
        else agent.destination = _walkPoint;

        if(agent.remainingDistance <= 0f)
        {
            _walkPointSet = false;
            ThinkAboutNextDestination();
        }
    }

    void ThinkAboutNextDestination()
    {
        float _randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float _randomX = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + _randomX, transform.position.y, transform.position.z + _randomZ);
        _walkPointSet = true;
    }

    void WantsThePlayerDead()
    {
        _angerTimeLeft -= Time.deltaTime;   
        agent.SetDestination(_player.position);
        if (agent.remainingDistance < attackRange) AttackPlayer();

        if(_angerTimeLeft <= 0f)
        {
            _playerHitCounter = 0;
            _angerTimeLeft = angerDuration;
        }
    }

    void AttackPlayer()
    {

    }

    void TakeHit()
    {

    }
}
