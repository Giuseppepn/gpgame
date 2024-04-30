using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        Waiting
    }

    private State state;
    private SlimeController slimeController;
    private Animator animator;
    private void Awake()
    {
        slimeController = GetComponent<SlimeController>();
        animator = GetComponent<Animator>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    private IEnumerator RoamingRoutine()
    {
        //while (state == State.Roaming)
        //{
        //    animator.SetBool("isMoving", true);
        //    Vector2 roamPosition = GetRoamingPosition();
        //    slimeController.MoveTo(roamPosition);
        //    yield return new WaitForSeconds(2f);
        //    state = State.Waiting;
        //}

        //while(state == State.Waiting)
        //{
        //    animator.SetBool("isMoving", false);
        //    yield return new WaitForSeconds(2f);
        //    state = State.Roaming;

        //}

        while(state == State.Roaming || state == State.Waiting)
        {
            if(state  == State.Waiting)
            {
                animator.SetBool("isMoving", false);
                yield return new WaitForSeconds(2f);
                state = State.Roaming;
            }
            else if (state == State.Roaming)
            {
                animator.SetBool("isMoving", true);
                Vector2 roamPosition = GetRoamingPosition();
                slimeController.MoveTo(roamPosition);
                yield return new WaitForSeconds(2f);
                state = State.Waiting;
            }
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
