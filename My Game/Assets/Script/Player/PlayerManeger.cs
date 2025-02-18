using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour
{
    public static PlayerManeger instance;

    public Player player;

    
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    
}
