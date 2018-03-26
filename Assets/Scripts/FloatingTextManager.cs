using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : Singleton<FloatingTextManager>
{

    private GameObject popupText;
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        if (!popupText)
        {
            popupText = Resources.Load<GameObject>("Prefabs/PopupTextParent");
            print("created");
        }
            

       
    }


    public void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText).GetComponentInChildren<FloatingText>();
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(location.position);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPoint;
        instance.SetText(text);
    }

}
