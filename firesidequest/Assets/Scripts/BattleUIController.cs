using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BattleUIController : MonoBehaviour
{

    public UnityEngine.UI.Button[] objs;


    // Start is called before the first frame update
    public void Start()
    {
        foreach (UnityEngine.UI.Button btn in objs) {
            btn.onClick.AddListener(()=> {
                var colors = btn.colors;
                colors.selectedColor = Color.red;
                btn.colors = colors;
            });
        }  
    }

    // Update is called once per frame
    void Update()
    {

    }


}
