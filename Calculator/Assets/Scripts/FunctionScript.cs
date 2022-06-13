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
    public void Function()
    {
        operation = buttonText.text;
        switch (operation)
        {
            case "C":
                global.currentExpression.text = null;
                global.currentValue.text = "0";
                global.nullText = true;
                global.saveButtonText = null;
                global.a = 0;
                global.b = 0;
                global.nowB = false;
                global.memoryReset = false;
                break;
            case "CE":
                if (global.currentExpression.text.EndsWith("="))
                {
                    //тут міг би використати todo, але я не буду)))))
                    global.currentExpression.text = null;
                    global.currentValue.text = "0";
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.a = 0;
                    global.b = 0;
                    global.nowB = false;
                    global.memoryReset = false;
                }
                else
                {
                    global.currentValue.text = "0";
                    global.nullText = true;
                    global.memoryReset = false;
                }
                break;
            case "^0.5":
                if (global.a < 0)
                {
                    global.currentValue.text = "Неверное значение";
                    global.currentExpression.text = null;
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.a = 0;
                    global.b = 0;
                    global.nowB = false;
                    global.memoryReset = false;
                }
                else if (string.IsNullOrEmpty(global.currentExpression.text) ^ global.currentExpression.text.EndsWith("="))
                {
                    
                    global.currentExpression.text = Convert.ToString(global.a) + operation;
                    global.a = Math.Sqrt(global.a);
                    global.currentValue.text = Convert.ToString(global.a);
                    global.memoryReset = false;
                    global.b = global.a;

                }
                else if (global.b < 0)
                {
                    global.currentValue.text = "Неверное значение";
                    global.currentExpression.text = null;
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.a = 0;
                    global.b = 0;
                    global.nowB = false;
                    global.memoryReset = false;
                }
                else
                {
                    global.nowB = true;
                    global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + "(" + Convert.ToString(global.b) + ")" + operation;
                    global.b = Math.Sqrt(global.b);
                    global.currentValue.text = Convert.ToString(global.b);                    
                    global.memoryReset = true;
                   // global.a = global.b;
                }
                break;
            case "^2":
                if (string.IsNullOrEmpty(global.currentExpression.text) ^ global.currentExpression.text.EndsWith("="))
                {
                    
                    global.currentExpression.text = Convert.ToString(global.a) + operation;
                    global.a = Math.Pow(global.a, 2);
                    global.currentValue.text = Convert.ToString(global.a);                    
                    global.memoryReset = true;
                    
                    global.b = global.a;
                    
                }
                else
                {
                    global.nowB = true;
                    global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + "(" + Convert.ToString(global.b) + ")" + operation;
                    global.b = Math.Pow(global.b, 2);
                    global.currentValue.text = Convert.ToString(global.b);                    
                    global.memoryReset = true;
                    //global.a = global.b;
                }
                break;
            case "1/x":
                if (global.currentValue.text == "0")
                {
                    global.currentValue.text = "Деление на ноль";
                    global.currentExpression.text = null;
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.a = 0;
                    global.b = 0;
                    global.nowB = false;
                }
                else if (string.IsNullOrEmpty(global.currentExpression.text) ^ global.currentExpression.text.EndsWith("="))
                {
                    global.currentExpression.text = "1/" + "(" + Convert.ToString(global.a) + ")";
                    global.a = 1 / global.a;
                    global.currentValue.text = Convert.ToString(global.a);
                    global.nowB = true;
                    global.memoryReset = true;                    
                }
                else
                {
                    global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + "1/" + "(" + Convert.ToString(global.b) + ")";
                    global.b = 1 / global.b;
                    global.currentValue.text = Convert.ToString(global.b);
                    global.nowB = true;
                    global.memoryReset = true;
                    global.a = global.b;
                }
                break;
            case "%":
                switch (global.saveButtonText)
                {
                    case "+":
                    case "-":
                        global.nowB = true;
                        global.b = global.a * global.b / 100;
                        global.currentValue.text = Convert.ToString(global.b);
                        global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + Convert.ToString(global.b);
                        global.memoryReset = false;
                        break;
                    case "/":
                    case "*":
                        global.nowB = true;
                        global.b = global.b / 100;
                        global.currentValue.text = Convert.ToString(global.b);
                        global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + Convert.ToString(global.b);
                        global.memoryReset = false;
                        break;
                }
                break;
            case "<=":
                if (global.currentExpression.text.EndsWith("="))
                {
                    global.currentExpression.text = null;
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.b = 0;
                    global.nowB = false;
                    global.operationBlocker = false;
                    global.memoryReset = false;
                }
                else
                {
                    global.currentValue.text = global.currentValue.text.Remove(global.currentValue.text.Length - 1);
                    global.memoryReset = false;
                }
                break;
            case "+/-":
                if (string.IsNullOrEmpty(global.currentExpression.text))
                {
                    global.a = global.a * -1;
                    global.currentValue.text = Convert.ToString(global.a);
                    global.memoryReset = false;
                }
                else
                {
                    global.b = global.b * -1;
                    global.currentValue.text = Convert.ToString(global.b);
                }
                break;
            case "=":
                if (global.saveButtonText == "/" & global.b == 0)
                {
                    global.currentValue.text = "Деление на ноль";
                    global.currentExpression.text = default;
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.a = 0;
                    global.b = 0;
                    global.nowB = false;
                }
                else if (global.b == 0)//необхідно для корректного відображення при нульовому значенні b
                {
                    global.currentExpression.text = Convert.ToString(global.a) + operation;
                    global.memoryReset = true;
                }
                else
                {
                    global.currentExpression.text = Convert.ToString(global.a) + global.saveButtonText + Convert.ToString(global.b) + operation;
                    Precalculation();
                    global.currentValue.text = Convert.ToString(global.a);
                    global.nowB = false;
                    global.operationBlocker = true;
                    global.memoryReset = true;
                }
                break;
            default:
                if (global.saveButtonText == "/" & global.b == 0)
                {
                    global.currentValue.text = "Деление на ноль";
                    global.currentExpression.text = default;
                    global.nullText = true;
                    global.saveButtonText = null;
                    global.a = 0;
                    global.b = 0;
                    global.nowB = false;
                }
                else if (!global.operationBlocker)
                {
                    global.operationBlocker = true;
                    global.nowB = true;
                    Precalculation();
                    global.currentExpression.text = Convert.ToString(global.a) + operation;
                    global.currentValue.text = Convert.ToString(global.a);
                    global.nullText = true;
                    global.saveButtonText = operation;
                    global.memoryReset = false;
                }
                else//дозволяє переключати математичні операції до ввода другого числа
                {
                    global.nullText = true;
                    global.currentExpression.text = Convert.ToString(global.a) + operation;
                    global.saveButtonText = operation;
                    global.memoryReset = false;
                }
                break;
        }
    }





}
