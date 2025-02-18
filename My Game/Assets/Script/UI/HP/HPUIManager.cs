using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����˵��ü���hp�Ĵ��������ٶ�Ӧ��hp��������߻�Ѫ�͵�������HP�Ĵ��������п��ơ�
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
    //index�����ڻ��ж���Ѫ��count������˶����˺���
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
    //������ǻ���Ѫ����Ȼ���ǻض�Ӧ��Ѫ��
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
