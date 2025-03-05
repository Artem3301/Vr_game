using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    NavMeshAgent agent;
    public float wanderRadius = 10f;
    public float wanderTimer = 5f;
    private float timer;
    public Animator anim;

    //[SerializeField] private Animator chickenAnimator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        if (timer <= 0)
        {
            anim.SetBool("isWalking", false);
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = wanderTimer;
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", true);
        }

        //chickenAnimator.SetBool("isWalking", true); // пишешь это когда курица должна воспроизводить анимацию ходьбы
        //chickenAnimator.SetBool("isWalking", false); // пишешь это когда курица должна стоять
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, layermask);
        return navHit.position;
    }
}
