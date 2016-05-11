using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    public Transform[] targets;

    public NavMeshAgent agent;

    public CharacterController character;

    Vector3 currentTarget;

    public Animator animator;

    int index = 1;//当前位置
    public bool isMoving = false; //是否在移动中
    // Use this for initialization
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        //agent.SetDestination(targets[index].position);
        if (character == null)
        {
            character = GetComponent<CharacterController>();

        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    /// <summary>
    /// 是否可以向左边移动
    /// </summary>
    /// <returns></returns>
    public bool CanMoveLeft()
    {
        return index > 0;
    }
    /// <summary>
    /// 是否可以向右边移动
    /// </summary>
    /// <returns></returns>
    public bool CanMoveRight()
    {
        return index < targets.Length - 1;
    }

    void Update()
    {
        // agent.
        if (agent.enabled)
        {
            if (agent.remainingDistance < 0.1f)
            {
                agent.enabled = false;
                //isMoving = false;
            }
            else
            {
                animator.SetFloat("_speed", agent.velocity.magnitude);

                //  float angle = Vector3.Angle(transform.forward, (targets[index].position - transform.position).normalized);
                float angle = Vector3.Cross(transform.position, targets[index].position).y;
                //Debug.Log(angle);
                animator.SetFloat("_angle", angle);
                animator.SetFloat("_distance", agent.remainingDistance);
            }
        }
        //if( agent.remainingDistance < 0.1f)
        //{
        //    if(currentColdDown >=5)
        //    {
        //        index = (index + 1) % targets.Length;
        //        agent.enabled = true;
        //        agent.SetDestination(targets[index].position);
        //        currentColdDown = 0;
        //    }
        //    else
        //    {
        //        currentColdDown += Time.deltaTime;
        //        agent.enabled = false;
        //    }

        //Debug.Log(agent.velocity);
        //   }




        // Debug.Log(character.velocity);

        //Vector3 dirction = target.position - transform.position;
        //dirction.y = 0;
        //if(dirction.magnitude > 0.1)
        //{
        //    Vector3 currentVelocity = Vector3.zero;
        //    Vector3 n = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //    Debug.Log(n);
        //    Vector3 afterDamp = Vector3.SmoothDamp(transform.position, target.position, ref currentVelocity, Time.deltaTime * speed);
        //    float angle = Quaternion.Angle(Quaternion.FromToRotation(Vector3.forward, transform.forward), Quaternion.FromToRotation(Vector3.forward, currentVelocity));
        //   // Debug.Log(angle);
        //   // Debug.Log(currentVelocity);
        //    transform.position = n;
        //}

    }
    /// <summary>
    /// 向左或向右移动
    /// </summary>
    /// <param name="i">i>0时向右移动, i < 0 时向左移动</param>
    public void MoveDirection(int i)
    {
        if (i > 0)
        {
            MoveTo(index + 1);
        }
        else
        {
            MoveTo(index - 1);
        }
    }
    /// <summary>
    /// 移动到位置数组中的第几个位置
    /// </summary>
    /// <param name="i">数组的位置</param>
    public void MoveTo(int i)
    {
        int len = targets.Length;
        if (len <= 0 || isMoving)
            return;
        index = i;
        while (index < 0 || index >= len)
        {
            if (index < 0)
                index += len;
            if (index >= len)
                index -= len;
        }
        //index = i % targets.Length;
        agent.enabled = true;
        //isMoving = true;
        transform.LookAt(targets[index].position);
        agent.SetDestination(targets[index].position);
    }
}
