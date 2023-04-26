using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

   [SerializeField] private Animator unitAnimator;
    private Vector3 targetPos;

    private void Awake()
    {
        targetPos = transform.position;
    }

    private void Update() 
    {
      
        float stoppingDist = .1f; //Distance to stop before new pos

        if (Vector3.Distance(transform.position, targetPos) > stoppingDist)
        {
            Vector3 moveDirection = (targetPos - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward,moveDirection,Time.deltaTime * rotateSpeed); //rotating the unit when moving + Lerp makes it smooth

            unitAnimator.SetBool("isWalking",true); //sets the walkign animation to true on click 
        } 

        else
        {
            unitAnimator.SetBool("isWalking",false);
        }
        
    }
   public void Move (Vector3 targetPos)
   {
        this.targetPos = targetPos;
   }
}
