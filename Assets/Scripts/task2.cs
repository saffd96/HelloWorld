using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task2 : MonoBehaviour
{
    public Text start;

    private int sum = 0;
    private int count = 0;
    [Range(25, 50)]
    [SerializeField]
    private int maxSum = 50;
    void Start()
    {
        start.text = $"Нажми цифру:";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            sum += 0;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            sum += 1;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            sum += 2;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            sum += 3;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            sum += 4;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            sum += 5;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            sum += 6;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            sum += 7;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            sum += 8;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            sum += 9;
            UpdateSum();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Default();
            start.text = $"Настройки сброшены до настроек по-умолчанию.\nТекущая сумма 0\nНажми цифру:";
        }
        if (sum >= maxSum)
        {
            start.text = $"Поздравляю. Игра окончена.\nВы потратили {count} попыток";
            Invoke("Start", 2f);
            Default();
        }
    }
    void UpdateSum()
    {
        start.text = $"Сумма: {sum}";
        count++;
    }
    void Default()
    {
        count = 0;
        sum = 0;
    }
}
