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
        //update player position
        //multiply time so that it doesn't move every update but to time
        transform.position += moveDir * moveSpeed * Time.deltaTime;

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
