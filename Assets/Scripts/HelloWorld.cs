using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    public Text label;

    [Range(1,500)]
    public int min = 1;

    [Range(501, 1000)]
    public int max = 1000;
    private int guess;
    void Start()
    {
        print($"Загадай число от {min} до {max}");
        UpdateGuess();
    }
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
            print("Game Over");
        }
    }
    void UpdateGuess()
    {
        guess = (min + max) / 2;
        label.text = $"Твое число равно {guess}?";
    }
}
