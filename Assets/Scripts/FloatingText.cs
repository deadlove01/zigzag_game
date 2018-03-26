using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Animator anim;
     public TextMeshProUGUI popupText;

	// Use this for initialization
	void Start ()
	{
	    AnimatorClipInfo[] clips= anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clips[0].clip.length);
	   // popupText = GetComponent<TextMeshProUGUI>();
	}

    public void SetText(string text)
    {
        popupText.text = text;
    }
}
