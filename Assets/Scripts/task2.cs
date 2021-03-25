﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task2 : MonoBehaviour
{
    public Text start;

    private int sum = 0;
    private int counts = 0;
    [Range(25, 50)] [SerializeField]
    private int maxSum = 50;
    void Start()
    {
        start.text = $"Нажмите цифру.";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            sum += 0;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            sum += 1;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            sum += 2;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            sum += 3;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            sum += 4;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            sum += 5;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            sum += 6;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            sum += 7;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            sum += 8;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            sum += 9;
            UpdateSum();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sum = 0;
            start.text = $"Настройки сброшены до настроек по-умолчанию.\nТекущая сумма 0\nНажми цифру:";
        }
        if (sum >= maxSum)
        {
            start.text = $"Поздравляю. Игра окончена.\nВы потратили {counts} попыток";
        }
    }
    void UpdateSum()
    {
        start.text = $"Сумма: {sum}";
        counts++;
    }
}
