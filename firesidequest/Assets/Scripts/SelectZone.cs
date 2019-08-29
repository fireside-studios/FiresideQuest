using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectZone : MonoBehaviour
{
    public Transform selectZoneTransform;
    public Color startColor;
    public Color mouseOverColor;
    bool mouseOver = false;
    SpriteRenderer selectZoneSprite;
    

    private void Start()
    {
        mouseOver = true;
        selectZoneSprite = transform.GetComponent<SpriteRenderer>();
        selectZoneSprite.color = startColor;
    }

    private void OnMouseEnter()
    {
        selectZoneSprite.color = mouseOverColor;
    }

    private void OnMouseExit()
    {
        selectZoneSprite.color = startColor;
    }

}
