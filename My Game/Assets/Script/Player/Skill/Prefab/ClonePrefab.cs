using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePrefab : MonoBehaviour
{
    [SerializeField]private Player player;

    [SerializeField]private string currentAnimTrigger;
    [SerializeField] private string newAnimTrigger;

    [SerializeField]private Transform attackTransform;
    [SerializeField]private float attackDeteRadius;

    private Animator anim;
    private Rigidbody2D rb;
    private PlayerStateMachine stateMachine;

    public float faceDir;
    public bool faceRight;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Start()
    {
        faceDir = 1;
        faceRight = true;
        stateMachine = player.stateMachine;
        currentAnimTrigger = stateMachine.currentState.animName;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if(currentAnimTrigger == "Skill")
        {
            //有的技能在某种特殊持续时间内只会调用一次，但会改变角色状态
            if (player.currentSkill != null)
                currentAnimTrigger = player.currentSkill.animTrigger;
            else
                currentAnimTrigger = "";
        }

        anim.SetBool(currentAnimTrigger, true);

        if (faceDir != player.faceDir) 
        {
            FlipController(player.faceDir);
        }

    }

    private void Update()
    {
        if (PuaseManager.instance.isPause)
            return;
        rb.velocity = new Vector2(player.rb.velocity.x * player.cloneDir, player.rb.velocity.y);
        
        anim.SetInteger("AttackCount", player.attackCount);

        FlipController(rb.velocity.x);
       

        if (stateMachine.isChangeState) 
        {
            newAnimTrigger = stateMachine.newState.animName;

            if (newAnimTrigger == "Skill")
            {
                //有的技能在某种特殊持续时间内只会调用一次，但会改变角色状态
                if (player.currentSkill != null)
                    newAnimTrigger = player.currentSkill.animTrigger;
                else
                    newAnimTrigger = "";
            }
            anim.SetBool(currentAnimTrigger, false);
            anim.SetBool(newAnimTrigger, true);
            currentAnimTrigger = newAnimTrigger;
            stateMachine.isChangeState = false;
        }       
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackDeteRadius);
    }
    private void FlipController(float _xVelocity)
    {
        if (currentAnimTrigger == "Defense" || newAnimTrigger == "Defense") 
        {
            return;
        }
         if (_xVelocity * faceDir < 0)
        {
            rb.transform.Rotate(0, 180, 0);
            faceRight = !faceRight;
            faceDir *= -1;
        }
    }

    public void Dead() 
    {
        Destroy(this.gameObject);
    }
}
