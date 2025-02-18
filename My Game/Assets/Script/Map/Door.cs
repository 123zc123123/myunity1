using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,ISave
{
    [SerializeField] private GameObject door;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite doorSprite;

    [SerializeField] private Animator onAnim;
    [SerializeField] private Animator doorAnim;
    [SerializeField] private int doorIndex;
    private bool isTrigger;
    private Player player;

    private void Start()
    {
        player = PlayerManeger.instance.player;
        isTrigger = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(2);
        if (collision.GetComponent<Player>() != null && Input.GetKeyDown(KeyCode.F)) 
        {
            Debug.Log(1);
            player.stateMachine.ChangeState(player.dictionState);
            onAnim.SetBool("On", true);
        }
    }

    private void DoorAnimStart()
    {
        doorAnim.SetBool("Door", true);
        SpriteRenderer onSpriteRenderer = this.GetComponent<SpriteRenderer>();
        onSpriteRenderer.sprite = onSprite;
    }

    private void DoorAnimOver() 
    {
        SpriteRenderer doorSpriteRenderer = door.GetComponent<SpriteRenderer>();
        doorSpriteRenderer.sprite = doorSprite;
        door.GetComponent<BoxCollider2D>().enabled = false;
        isTrigger = true;
        player.stateMachine.ChangeState(player.idleState);
    }

    public void Save(ref SaveStruct _saveDate)
    {
        _saveDate.doorIsTrigger[doorIndex] = isTrigger;
    }

    public void Load(SaveStruct _loadDate)
    {
        isTrigger = _loadDate.doorIsTrigger[doorIndex];
        if (isTrigger) 
        {
            SpriteRenderer onSpriteRenderer = this.GetComponent<SpriteRenderer>();
            onSpriteRenderer.sprite = onSprite;
            SpriteRenderer doorSpriteRenderer = door.GetComponent<SpriteRenderer>();
            doorSpriteRenderer.sprite = doorSprite;
            door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
