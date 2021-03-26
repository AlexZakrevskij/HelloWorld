using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    public Text label;
    public int min = 1;

    public int max = 1000;

    private int guess;
    // Start is called before the first frame update
    void Start()
    {
        print("Make a wish your number from " + min +" to " + max);
        UpdateGuess();
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
            print("Game Over!");
        }
    }

    private void UpdateGuess()
    {
        guess = (min + max) / 2;
        label.text = "Are you wish that number " + guess + "?";
        print("Are you wish that number " + guess +"?");
    }
}
