using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    public Text label;
    private int count = 0;

    [Range(1,500)][SerializeField]
    private int min = 1;

    [Range(501, 1000)][SerializeField]
    private int max = 1000;

    private int guess;

    void Start()
    {
        label.text = $"Загадай число от {min} до {max}";
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
            label.text = $"Game Over!\nКоличество затраченых попыток - {count}";
            enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            min = 1;
            max = 1000;
            label.text = $"Настройки сброшены до настроек по-умолчанию. \nЗагадай число от {min} до {max}";

            Invoke("UpdateGuess", 2f);
        }
    }
    void UpdateGuess()
    {
        guess = (min + max) / 2;
        label.text = $"Твое число равно {guess}?";
        count++;
    }
}
