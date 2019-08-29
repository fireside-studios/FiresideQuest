using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;

    public void SetSize(float SizeNormalized) {
        bar.localScale = new Vector3(SizeNormalized, 1f);
    }
}
