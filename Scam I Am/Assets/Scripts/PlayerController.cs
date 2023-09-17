using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float collisionOffset = 0.01f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate(){
        if(canMove){
            // if movement input is not 0, try to move
            if(movementInput != Vector2.zero){
                bool success = TryMove(movementInput);
                if(!success){
                    success = TryMove(new Vector2(movementInput.x, 0));
                }
                if(!success){
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                if(success){
                    animator.SetFloat("Horizontal", movementInput.x);
                    animator.SetFloat("Vertical", movementInput.y);       
                }
            }
            animator.SetFloat("Speed", movementInput.sqrMagnitude);
        }
      
    }

    private bool TryMove(Vector2 direction){
        if(direction == Vector2.zero){
            return false;
        }

        int count = rb.Cast(direction, movementFilter, castCollisions, moveSpeed*Time.fixedDeltaTime + collisionOffset);
        if(count == 0){
            rb.MovePosition(rb.position + direction*moveSpeed*Time.fixedDeltaTime);
            return true;
        }
        return false;
    }
    
    // WASD or arrow keys 
    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
    // left mouse button
    void OnFire(){
        
    }

    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }

   
}
