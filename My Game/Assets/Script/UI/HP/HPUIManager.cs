using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//受伤了调用减少hp的代码来减少对应的hp，复活或者回血就调用增加HP的代码来进行控制。
public class HPUIManager : MonoBehaviour
{
    public static HPUIManager instance;
    [SerializeField] private List<GameObject> hPSlot;

    [SerializeField] private Sprite fullHPImage;
    [SerializeField] private Sprite emptyHPImage;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
    //index是现在还有多少血，count是造成了多少伤害。
    public void DecreaseHP(int _index,int _count) 
    {
       
        if (_index < 0)
        {
            _index = 0;
            _count = 1;
        }
        for (int i = 0; i < _count; i++) 
        {
            hPSlot[_index + i].GetComponent<Image>().sprite = emptyHPImage;
        }
    }
    //复活就是回满血，不然就是回对应的血。
    public void IncreaseHP(int _index, bool _isRivive) 
    {
        if (_isRivive)
        {
            foreach (GameObject hp in hPSlot)
            {
                hp.GetComponent<Image>().sprite = fullHPImage;
            }
        }
        else 
        {
            hPSlot[_index-1].GetComponent<Image>().sprite = fullHPImage;
        }
    }
}
