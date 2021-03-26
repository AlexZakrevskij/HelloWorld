using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class SumNumber : MonoBehaviour
{
    private int sum = 0;
    private int toWin = 50;
    private int sumTry = 0;
    public Text bgnMsg;
    public Text endMsg;

    private KeyCode[] numPress =
    {
        KeyCode.Keypad0, KeyCode.Keypad1, KeyCode.Keypad2,
        KeyCode.Keypad3, KeyCode.Keypad4, KeyCode.Keypad5,
        KeyCode.Keypad6, KeyCode.Keypad7, KeyCode.Keypad8,
        KeyCode.Keypad9
    };
    // Start is called before the first frame update
    void Start()
    {
        bgnMsg.text = "Нажимайте цифры от 1 до 9 на доп.клавиатуре";
        updRule();
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numPress.Length; i++)
        {
            if (Input.GetKeyDown(numPress[i]))
            {
                sum += i;
                updRule();
            }
        }

        if (sum >= toWin)
        {
            endMsg.text =
                $"Игра окончена. Сумма: {sum} \n, ходов затрачено: {sumTry} \nДля новой игры нажмите 'ПРОБЕЛ'";
            //print("Игра окончена. Сумма: " + sum + "\n, ходов затрачено: "+sumTry);
            //print("Для новой игры нажмите 'ПРОБЕЛ'");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sum = 0;
            sumTry = 0;
            updRule();
        }
    }

    void updRule()
    {
        sumTry++;
        endMsg.text = $"Нажимайте цифру\n Сумма: {sum}";
        //print("Нажимайте цифру\n Сумма: "+sum);
    }
}
