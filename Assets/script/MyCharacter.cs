using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyCharacter : MonoBehaviour
{
    public float speed;
    public Vector3 _Destination;
    private Animator anim;
    public bool moveEnable = false;
    public NavMeshAgent navmeshh;
    void Start()
    {
        _Destination = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    public void SetTarget(Vector3 TargetPos)
    {
        _Destination = TargetPos;
        //Debug.Log(TargetPos);
        moveEnable = true;
        navmeshh.SetDestination(TargetPos);
        navmeshh.speed = speed;
        anim.SetFloat("walkspeed", 1.0f);

    }

    void FixedUpdate()
    {
     if(moveEnable)
        {
            //navmeshh.SetDestination(_Destination);
            if(!navmeshh .pathPending)
            {
                float dis = navmeshh.remainingDistance;
                //Debug.Log(dis);
                if (dis < 0.5f)
                {
                    navmeshh.SetDestination(transform.position);
                    moveEnable = false;
                    anim.SetFloat("walkspeed", 0.0f);
                }
            }
           
        } 
    }

    void normalmove()
    {
        if (!moveEnable) return;
        Vector3 MoveDirection = _Destination - transform.position;

        if (MoveDirection.magnitude > 0.5f)
        {
            MoveDirection.Normalize();
            Quaternion qua = Quaternion.LookRotation(MoveDirection);
            transform.rotation = Quaternion.LookRotation(MoveDirection);
            transform.Translate(MoveDirection * Time.deltaTime * speed);
            anim.SetFloat("walkspeed", 1.0f);

        }
        else
        {
            anim.SetFloat("walkspeed", 0.0f);
            moveEnable = false;
        }
    }
}
