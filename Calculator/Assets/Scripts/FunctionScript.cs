using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class FunctionScript : MonoBehaviour
{

    public Text buttonText;
    public CurrentExpressionScript global;
    string operation;


    public void Function()
    {
        operation = buttonText.text;

        void Precalculation()
        {
            switch (global.saveButtonText)
            {
                case "+":
                    global.a += global.b;
                    break;
                case "-":
                    global.a -= global.b;
                    break;
                case "*":
                    global.a *= global.b;
                    break;
                case "/":
                    global.a /= global.b;
                    break;
            }
        }

        switch (operation)
        {
            case "=":
                if (global.saveButtonText == "/" & global.b == 0)
                {
                    Clean();
                    global.currentExpression.text = "Неможливо розділити на нуль";
                }
                else if (string.IsNullOrEmpty(global.currentExpression.text))//необхідно для корректного відображення при нульовому значенні b
                {
                    global.currentExpression.text = Convert.ToString(global.a) + operation;
                    global.memoryReset = true;
                    global.backSpaceBlock = true;
                }
                else
                {
                    if (global.currentExpression.text.EndsWith("="))
                    {
                        global.b = global.saveB;
                        global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + Convert.ToString(global.b) + operation;
                        Precalculation();
                        //global.nowB = false;
                        global.currentValue.text = Convert.ToString(global.a);
                        global.operationBlocker = true;
                    }
                    else
                    {
                        //global.nowB = false;
                        global.saveB = global.b;
                        global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + Convert.ToString(global.b) + operation;
                        Precalculation();
                        global.currentValue.text = Convert.ToString(global.a);
                        global.operationBlocker = true;
                        global.memoryReset = true;
                        global.backSpaceBlock = false;
                    }
                }
                break;
            default:
                if (!global.operationBlocker)
                {
                    if (global.b == 0 & global.saveButtonText == "/")
                    {                        
                        Clean();
                        global.currentExpression.text = "Неможливо розділити на нуль";
                    }
                    else
                    {
                        global.operationBlocker = true;
                        global.nowB = true;
                        Precalculation();
                        global.currentExpression.text = Convert.ToString(global.a) + operation;
                        global.nullText = true;
                        global.saveButtonText = operation;
                        global.memoryReset = false;
                        global.backSpaceBlock = false;
                    }
                }
                else//дозволяє переключати математичні операції до ввода другого числа
                {
                    global.nullText = true;
                    global.currentExpression.text = Convert.ToString(global.a) + operation;
                    global.saveButtonText = operation;
                    global.memoryReset = false;
                    global.backSpaceBlock = false;
                }
                break;
        }
    }
    public void Clean()
    {
        global.currentExpression.text = null;
        global.currentValue.text = "0";
        global.nullText = true;
        global.saveButtonText = null;
        global.a = 0;
        global.b = 0;
        global.nowB = false;
        global.memoryReset = false;
        global.backSpaceBlock = true;
    }
    public void CleanEntry()
    {
        if (global.currentExpression.text.EndsWith("="))
        {
            Clean();
        }
        else
        {
            global.currentValue.text = "0";
            global.nullText = true;
            global.memoryReset = false;
            global.backSpaceBlock = true;
        }
    }
    public void SquareRoot()
    {
        if (Convert.ToDouble(global.currentValue.text) < 0)
        {
            Clean();
            global.currentExpression.text = "Корінь від'ємного числа не існує";
        }
        else if (string.IsNullOrEmpty(global.saveButtonText) ^ global.currentExpression.text.EndsWith("="))
        {
            global.currentExpression.text = Convert.ToString(global.a) + "^0.5";
            global.a = Math.Sqrt(global.a);
            global.currentValue.text = Convert.ToString(global.a);
            global.memoryReset = true;
            global.saveButtonText = null;
            global.backSpaceBlock = true;
        }
        else
        {
            global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + "(" + Convert.ToString(global.b) + ")^0.5";
            global.b = Math.Sqrt(global.b);
            global.currentValue.text = Convert.ToString(global.b);
            global.memoryReset = true;
            global.backSpaceBlock = true;
        }
    }
    public void Pow()
    {
        if (string.IsNullOrEmpty(global.saveButtonText) ^ global.currentExpression.text.EndsWith("="))
        {
            global.currentExpression.text = Convert.ToString(global.a) + "^2";
            global.a = Math.Pow(global.a, 2);
            global.currentValue.text = Convert.ToString(global.a);
            global.memoryReset = true;
            global.saveButtonText = null;
            global.backSpaceBlock = true;
        }
        else
        {
            global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + "(" + Convert.ToString(global.b) + ")^2";
            global.b = Math.Pow(global.b, 2);
            global.currentValue.text = Convert.ToString(global.b);
            global.memoryReset = true;
            global.backSpaceBlock = true;
        }
    }
    public void Reverse()
    {
        if (global.currentExpression.text.EndsWith("="))
        {
            global.a = Convert.ToDouble(global.currentValue.text) * -1;
            global.currentValue.text = Convert.ToString(global.a);
            Debug.Log(global.a);
        }
        else
        {
            if (global.currentValue.text.Contains("-"))
            {
                global.currentValue.text = global.currentValue.text.TrimStart('-');
            }
            else
            {
                global.currentValue.text = "-" + global.currentValue.text;
            }
        }
    }
    public void Backspace()
    {
        if (!global.backSpaceBlock)
        {
            if (global.currentExpression.text.EndsWith("="))
            {
                global.currentExpression.text = null;
                global.nullText = true;
                global.saveButtonText = null;
                global.nowB = false;
                global.b = 0;
                global.operationBlocker = false;
                global.memoryReset = false;
            }
            else
            {
                global.currentValue.text = global.currentValue.text.Remove(global.currentValue.text.Length - 1);
                global.memoryReset = false;
            }
        }
    }
    public void PartOfOne()
    {
        if (global.currentValue.text == "0")
        {
            Clean();
            global.currentExpression.text = "Неможливо розділити на нуль";
        }
        else if (string.IsNullOrEmpty(global.saveButtonText) ^ global.currentExpression.text.EndsWith("="))
        {
            global.currentExpression.text = "1/" + "(" + Convert.ToString(global.a) + ")";
            global.a = 1 / global.a;
            global.currentValue.text = Convert.ToString(global.a);
            global.memoryReset = true;
            global.saveButtonText = null;
            global.backSpaceBlock = true;
        }
        else
        {
            global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + "1/" + "(" + Convert.ToString(global.b) + ")";
            global.b = 1 / global.b;
            global.currentValue.text = Convert.ToString(global.b);
            global.memoryReset = true;
            global.backSpaceBlock = true;
        }
    }
    public void Percent()
    {
        switch (global.saveButtonText)
        {
            case "+":
            case "-":
                global.nowB = true;
                global.b = global.a * global.b / 100;
                global.currentValue.text = Convert.ToString(global.b);
                global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + Convert.ToString(global.b);
                global.memoryReset = false;
                global.backSpaceBlock = true;
                global.nullText = true;
                break;
            case "/":
            case "*":
                global.nowB = true;
                global.b = global.b / 100;
                global.currentValue.text = Convert.ToString(global.b);
                global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + Convert.ToString(global.b);
                global.memoryReset = false;
                global.backSpaceBlock = true;
                global.nullText = true;
                break;
        }
    }
}
