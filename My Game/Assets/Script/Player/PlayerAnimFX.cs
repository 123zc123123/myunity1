using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimFX : MonoBehaviour
{
    public Player player;

    private PlayerSkillManager skillManager;
    private void Start()
    {
        player = GetComponentInParent<Player>();
        skillManager = PlayerSkillManager.instance;
    }

    private void AnimationOver() 
    {
        player.DeteTrigger();
    }

    //再合适的时机创建风的预制体
    private void CreateWind() 
    {
        if(player.currentSkill==player.midWindSkill)
            player.midWindSkill.CreateWind();
        else if(player.currentSkill== player.maxWindSkill)
            player.maxWindSkill.CreateWind();
        else
            player.minWindSkill.CreateWind();
    }

    private void DoDamage()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackTransform.position, player.attackDeteRadius);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<BaseEnemy>() != null)
            {
                if (collider.GetComponent<BaseEnemy>().faceRight)
                    collider.GetComponent<BaseEnemy>().rb.velocity = new Vector2(-4, 0);
                else
                    collider.GetComponent<BaseEnemy>().rb.velocity = new Vector2(4, 0);
                player.playerAttribute.DoDamage(collider.GetComponent<EntityAtrribute>());
                
            }
        }
    }
}
