using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Ĭ��ͼƬ
    public Sprite sprite;
    //�л���ͼƬ
    public Sprite hoverSprite;

    private Image btnImage;
    // Start is called before the first frame update
    void Start()
    {
        btnImage = GetComponentInChildren<Image>();
    }
    
    //���������ͣ��UIԪ���ϵĲ���
    public void OnPointerEnter(PointerEventData eventData)
    {
        //�����ͣʱ�л�ͼƬ
        btnImage.sprite = hoverSprite;        
    }
    //��������Ƴ�UIԪ���ϵĲ���
    public void OnPointerExit(PointerEventData eventData)
    {
        btnImage.sprite = sprite;
    }    
}
