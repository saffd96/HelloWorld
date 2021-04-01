using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    public Text label;
    private int count = 0;

    [Range(1,500)][SerializeField]
    static private int min = 1;
    private int defMin = min;

    [Range(501, 1000)][SerializeField]
    static private int max = 1000;
    private int defMax = max;


    private int guess;

    void Start()
    {
        label.text = $"Загадай число от {min} до {max}";
        InitGuess();
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
            Default();
            Invoke("Start", 2f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Default();
            label.text = $"Настройки сброшены до настроек по-умолчанию. \nЗагадай число от {min} до {max}";
            Invoke("UpdateGuess", 2f);
        }
    }
    void InitGuess()
    {
        guess = (min + max) / 2;
        label.text = $"Твое число равно {guess}?";
    }
    void UpdateGuess()
    {
        InitGuess();
        count++;
    }
    void Default()
    {
        min = defMin;
        max = defMax;
        count = 0;
    }
}
