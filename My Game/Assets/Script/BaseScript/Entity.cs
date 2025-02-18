using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //检测
    [SerializeField] protected Transform groundTransform;
    public Transform attackTransform;
    [SerializeField] protected Transform wallTransform;
    [SerializeField] protected float groundDeteLength;
    [SerializeField] protected float wallDeteLength;
    public float attackDeteRadius;
    [SerializeField] protected LayerMask whatIsGround;

    

    public bool isDead;

   

    public Rigidbody2D rb;

    public Animator anim;

    public bool faceRight;
    //面对方向，右边为1左边为-1
    public float faceDir;

    public float moveSpeed;
    //用于控制人物是否能够切换状态
    public bool isBusy;

    protected virtual void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        
       
        isDead = false;
        faceDir = 1;
        faceRight = true;
        
    }

    protected virtual void Update()
    {
        
    }

    //画线
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundTransform.position, new Vector3(groundTransform.position.x, groundTransform.position.y - groundDeteLength));
        Gizmos.DrawLine(wallTransform.position, new Vector3(wallTransform.position.x + wallDeteLength * faceDir, wallTransform.position.y));
        Gizmos.DrawWireSphere(attackTransform.position, attackDeteRadius);
    }
    //检测是否有墙和地面
    public virtual bool DeteGround() => Physics2D.Raycast(groundTransform.position, Vector2.down, groundDeteLength, whatIsGround);
    public virtual bool DeteWall() => Physics2D.Raycast(wallTransform.position, Vector2.right * faceDir, wallDeteLength, whatIsGround);

    public void SetVelocity(float _xVelocity, float _yVelocity) 
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);

        FlipController(_xVelocity);
    }

    private void FlipController(float _xVelocity) 
    {
        if (_xVelocity * faceDir < 0)
        {
            rb.transform.Rotate(0, 180, 0);
            faceRight = !faceRight;
            faceDir *= -1;
        }
    }

    

    public virtual void SetZeroVelocity() 
    {
        rb.velocity = new Vector2(0, 0);
    }
    //对象死亡时调用
    public virtual void SetDeadState() 
    {
        isDead = true;
    }
   
}
       
