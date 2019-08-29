using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectZone : MonoBehaviour
{
    public Transform selectZoneTransform;
    public Transform selector;
    public Color startColor;
    public Color mouseOverColor;
    SpriteRenderer selectZoneSprite;
    SpriteRenderer selectorSprite;
    

    private void Start()
    {
        selectZoneSprite = selectZoneTransform.transform.GetComponent<SpriteRenderer>();
        selectZoneSprite.color = startColor;

        selectorSprite = selector.transform.GetComponent<SpriteRenderer>();
        selectorSprite.color = Color.clear;
    }

    private void OnMouseEnter()
    {
        selectZoneSprite.color = mouseOverColor;
    }

    private void OnMouseDown()
    {
        selectorSprite.color = Color.white;   
    }

    private void OnMouseExit()
    {
        selectZoneSprite.color = startColor;
    }

}
