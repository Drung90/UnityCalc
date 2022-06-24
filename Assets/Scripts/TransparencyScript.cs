using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TransparencyScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    bool buttonPressed;
    public Text buttonText;
    Color transpartncy;

    public void OnPointerDown(PointerEventData data)
    {
        buttonPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        buttonPressed = false;
    }

    private void Update()
    {
        buttonText.color = transpartncy;
        if (buttonPressed)
        {
            transpartncy.a = 0.5f;
        }
        else
        {
            transpartncy.a = 1f;
        }
    }
}
