using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Variables
    [SerializeField][Range(0.1f, 10.0f)]float MaxSpeed=0.1f;
    float MoveDirection=0;
    Rigidbody rigidbody;
    #endregion 
    #region Funtions Unity
    private void Start(){
        rigidbody=GetComponent<Rigidbody>();
       }
    void Update(){
        MoveDirection=Input.GetAxis("Horizontal");
    }
    void FixedUpdate(){
        Movement(MoveDirection);
    }
    #endregion
    #region Funtions Movement
    void Movement(float Horizontal){
       rigidbody.velocity=Vector2.right*Horizontal*MaxSpeed;
       flip(Horizontal);
    }
    void flip(float H){
        if(H>=0.1f){
            transform.localScale=Vector3.one;
            }else if(H<-0.0f){
           transform.localScale=new Vector3(-1,1,1); 
           Debug.Log("Flip_X");
            }
    }
    #endregion
}
