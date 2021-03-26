using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class MagicNumber : MonoBehaviour
{
    public Text answer;
    public Text count;
    public Text endGame;
    public int min = 1;

    public int max = 1000;
    private int i = 0;

    private int guess;
    // Start is called before the first frame update
    void Start()
    {
        answer.text = "Загадайте число от " + min +" до " + max;
        count.text = "Затраченные ходы:";
        endGame.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            UpdateGuess();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            UpdateGuess();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            EndGameMsg();
        }

        if (Input.GetKeyDown((KeyCode.Space)))
        {
            restartGame();
            Start();
        }
    }

    private void UpdateGuess()
    {
        guess = (min + max) / 2;
        answer.text = "Это число вы загадывали? " + guess + "?";
        i++;
    }

    private void restartGame()
    {
        min = 1;
        max = 1000;
        i = 0;
    }

    private void EndGameMsg()
    {
        count.text = "На угадывание затрачено ходов: " + i;
        endGame.text = "Игра окончена!";
    }
}
