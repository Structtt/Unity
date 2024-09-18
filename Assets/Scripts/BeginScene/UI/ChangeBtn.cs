using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //默认图片
    public Sprite sprite;
    //切换的图片
    public Sprite hoverSprite;

    private Image btnImage;
    // Start is called before the first frame update
    void Start()
    {
        btnImage = GetComponentInChildren<Image>();
    }
    
    //监听鼠标悬停在UI元素上的操作
    public void OnPointerEnter(PointerEventData eventData)
    {
        //鼠标悬停时切换图片
        btnImage.sprite = hoverSprite;        
    }
    //监听鼠标移出UI元素上的操作
    public void OnPointerExit(PointerEventData eventData)
    {
        btnImage.sprite = sprite;
    }    
}
