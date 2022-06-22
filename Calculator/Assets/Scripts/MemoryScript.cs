using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MemoryScript : MonoBehaviour
{
    public Text ButtonText;
    public CurrentExpressionScript global;  

    public void MemoryFunction()
    {
        switch (ButtonText.text)
        {
            case "MS":
                global.memoryCell = Convert.ToDouble(global.currentValue.text);
                global.nullText = true;
                break;
            case "MR":
                if (global.memoryReset)
                {
                    global.currentExpression.text = null;
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.a = 0;
                    global.b = 0;
                    global.nowB = false;
                    global.currentValue.text = Convert.ToString(global.memoryCell);
                    global.operationBlocker = false;                    
                }
                global.currentValue.text = Convert.ToString(global.memoryCell);
                break;
            case "MC":
                global.memoryCell = default;
                break;
            case "M+":
                global.memoryCell += Convert.ToDouble(global.currentValue.text);
                break;
            case "M-":
                global.memoryCell -= Convert.ToDouble(global.currentValue.text);
                break;
        }
    }
}
