using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoder : MonoBehaviour,ISave
{
    private bool canSave;

    public int index;
    private void Start()
    {
        canSave = false;
    }
    private void Update()
    {
        if (PuaseManager.instance.isPause)
            return;
        if (canSave) 
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PlayerManeger.instance.player.saveLoder = this;
                StartCoroutine(WaitForSave());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Player>() != null) 
        {
            canSave = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.GetComponent<Player>() != null)
        {
            canSave = false;
        }
    }

    public void Save(ref SaveStruct _saveDate)
    {
        
    }

    public void Load(SaveStruct _loadDate)
    {
        if (index == _loadDate.saveLoader) 
        {
            PlayerManeger.instance.player.saveLoder = this;
            PlayerManeger.instance.player.ReviveOnLoder();
        }
    }
    IEnumerator WaitForSave() 
    {
        yield return new WaitForSeconds(1f);
        SaveManager.instance.SaveGame();
    }
}
