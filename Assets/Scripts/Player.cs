using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //attribute allows us to view in unity editor, private alone doesn't let us
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;


    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        //convert to 3D vector best way to write code
        //watch necassary inputs and then convert if needed
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;

        //collison logic, capsule make it more accurate
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        //update player position
        //multiply time so that it doesn't move every update but to time
        if (canMove) {
            transform.position += moveDir * moveDistance;
        }

        //check if moving for aniamtion
        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        //rotates player to direction smoothly
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        Debug.Log(isWalking);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
