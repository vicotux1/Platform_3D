using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    #region Variables
    [Header("Player Movement")]
    [SerializeField][Range(0.1f, 10.0f)]float MaxSpeed=0.1f;
    [SerializeField][Range(0.1f, 10.0f)]float SpeedX=0,SpeedY=0;
    [SerializeField]string Axis_Horizontal="Horizontal",Axis_Vertical="Vertical";
    float MoveDirection=0;
    [SerializeField][Range(1, 2)]int serialID=1;
    [Header("Jump")]
    [SerializeField]string ButtonJump="Jump";
    [SerializeField]float Jump_Speed=600.0f;
    [SerializeField]bool IsGrounded=false;
    public Transform grounded_Check;
    public float Radius=2.0f;
    public LayerMask Layer;
    //Private Variables
    private new Rigidbody rigidbody;
    Animator anim;
    [Header ("Camera Follow")]
	[SerializeField] Vector3 _Distancia_a_seguir=Vector3.zero;
	[SerializeField][Range (0.01f, 1.0f)]float smoothSpeed=0.1f;
	[SerializeField]string AxisX="Mouse X", AxisY="Mouse Y";
	[SerializeField][Range (0, 90.0f)]float CameraRotate=30.0f;
    [SerializeField] Camera Main;
    #endregion 
    #region Funtions Unity
    private void Start(){
        rigidbody=GetComponent<Rigidbody>();
        anim=gameObject.GetComponent<Animator>();
        Cursor.visible = false;
		
        Main.transform.eulerAngles=new Vector3(CameraRotate,0,0);
       }
    private void Awake() {
        if(Main==null){
            Main=Camera.main;
        }
        if(grounded_Check==null){
            grounded_Check=GameObject.Find("Ground_Check").transform;
        }
    }  
    void FixedUpdate(){
        MoveDirection=Input.GetAxis(Axis_Horizontal);
        float MoveVertical=Input.GetAxisRaw(Axis_Vertical);
        IsGrounded=Physics2D.OverlapCircle(grounded_Check.position, Radius,Layer);
        bool b_Jump=Input.GetButtonDown(ButtonJump);
        _Jump(b_Jump);
        Movement(MoveDirection,MoveVertical);
    } 
    void LateUpdate(){
		float RotateX=Input.GetAxis(AxisX);
        float RotateY=Input.GetAxis(AxisY);
		Camera_follow();
	}
    #endregion
    #region Funtions Movement
    void Movement(float Horizontal, float Vertical){
        if(serialID==1){
            rigidbody.velocity=new Vector2(Horizontal*MaxSpeed, rigidbody.velocity.y);
       flip(Horizontal);
       anim.SetFloat("Speed",Horizontal);
        }if(serialID==2){
            rigidbody.velocity=new Vector3(Horizontal*SpeedX,0,Vertical*SpeedY);
       flip(Horizontal);
       anim.SetFloat("SpeedX",Horizontal);
       anim.SetFloat("SpeedY",Vertical);
        }
       
    }
    void flip(float H){
        if(H>=0.1f){
            transform.localScale=Vector3.one;
            }else if(H<-0.0f){
           transform.localScale=new Vector3(-1,1,1); 
           //Debug.Log("Flip_X");
            }
    }

    #endregion
    #region Camera Follow
    void Camera_follow(){
		Vector3 Seguir=transform.position +_Distancia_a_seguir;
		Vector3 Smooth=Vector3.Lerp(Main.transform.position,Seguir,smoothSpeed);
		Main.transform.eulerAngles=new Vector3(CameraRotate,0,0);
		Main.transform.position = Smooth;
		}
    #endregion
    #region Salto
    public void _Jump(bool is_jump){
        if(IsGrounded==true && is_jump ){
             rigidbody.AddForce(new Vector2(0,Jump_Speed));}
             }
    #endregion         
}
