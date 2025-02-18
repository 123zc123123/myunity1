using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    public static PlayerSkillManager instance;
    [SerializeField] private Player player;
    [SerializeField] private List<GameObject> prefabs;

    private void Awake()
    {
        if (instance != null) 
        {
            Destroy(instance.gameObject);
        }
        else 
        {
            instance = this;
        }
    }

    public GameObject CreatePrefab(int _prefabIndex,Vector3 _transfrom,Quaternion _quaternion)    
    {
        return Instantiate(prefabs[_prefabIndex], _transfrom, _quaternion);
    }
}
