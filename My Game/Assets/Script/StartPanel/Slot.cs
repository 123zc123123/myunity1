using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] protected Button button;
    protected virtual void Start()
    {
        button = GetComponent<Button>();
    }
    //�����ת��ʹ���޷����������뿪����
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<RectTransform>().sizeDelta *= new Vector2(1.2f, 1.2f);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<RectTransform>().sizeDelta /= new Vector2(1.2f, 1.2f);
    }
}
