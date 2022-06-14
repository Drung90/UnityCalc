using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CurrentExpressionScript : MonoBehaviour
{
    public bool nullText, nowB, operationBlocker, memoryReset, backSpaceBlock;
    public double a, b, memoryCell, saveB;
    public Text currentExpression, currentValue;
    public string saveButtonText;

    private void Start()
    {
        currentValue.text = "0";
        nullText = true;
    }
    private void Update()
    {

        if (!nowB)
        {
            a = Convert.ToDouble(currentValue.text);
        }
        else
        {
            b = Convert.ToDouble(currentValue.text);
        }
    }





}
