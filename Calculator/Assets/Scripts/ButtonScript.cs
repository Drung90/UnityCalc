using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text currentValue;
    public Text buttonText;
    public CurrentExpressionScript global;


    public void WriteSymbol()
    {
        global.operationBlocker = false;
        if (global.nullText)
        {
            currentValue.text = null;
            global.nullText = false;
        }
        else if (global.currentExpression.text.EndsWith("="))
        {
            global.currentExpression.text = null;
            global.currentValue.text = " ";
            global.nullText = false;
            global.saveButtonText = null;
            global.nowB = false;
            global.a = 0;
            global.b = 0;                       
        }
        
        if (currentValue.text.Length < 8)
            currentValue.text += buttonText.text;
    }


}
