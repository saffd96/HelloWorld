using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    public GreenPlayer greenPlayer;

    public int greenEnemyCurrentHp;
    public int greenEnemyCurrentAttack;
    public int greenEnemyCurrentPierce;

    public string greenEnemyCurrentName;

    public bool greenEnemyIsDead;

    [SerializeField]
    private TextMesh debugText;
    private TextMesh greenEnemyNameText;
    private TextMesh greenEnemyHpText;
    private TextMesh greenEnemyDeadText;

    private void Update()
    {
        UpdateInfo();
    }

    public void GetDamage(int damageValue)
    {
        if (greenEnemyIsDead == false)
        {
            if (damageValue > 0)
            {
                greenEnemyCurrentHp -= damageValue;
                print($"{greenPlayer.name} ударил {greenEnemyCurrentName} и нанес {damageValue} урона. " +
                    $"У {greenPlayer.name} осталось {greenPlayer.greenPlayerCurrentHp}. " +
                    $"У {greenEnemyCurrentName} осталось {greenEnemyCurrentHp}");
                debugText.text = $"{greenPlayer.name} ударил {greenEnemyCurrentName} и нанес {damageValue} урона." +
                    $"\nУ {greenPlayer.name} осталось {greenPlayer.greenPlayerCurrentHp}" +
                    $"\nУ {greenEnemyCurrentName} осталось {greenEnemyCurrentHp}";
            }
            else
            {
                print($"{greenPlayer.name} ударил {greenEnemyCurrentName} и не нанес урона. " +
                    $"У {greenPlayer.name} осталось {greenPlayer.greenPlayerCurrentHp}. " +
                    $"У {greenEnemyCurrentName} осталось {greenEnemyCurrentHp}");
                debugText.text = $"{greenPlayer.name} ударил {greenEnemyCurrentName} и не нанес урона." +
                    $"\nУ {greenPlayer.name} осталось {greenPlayer.greenPlayerCurrentHp}" +
                    $"\nУ {greenEnemyCurrentName} осталось {greenEnemyCurrentHp}";
            }
        }
    }

    public void UpdateInfo()
    {
        greenEnemyNameText.text = greenEnemyCurrentName;
        greenEnemyHpText.text = greenEnemyCurrentHp.ToString();
        if (greenEnemyCurrentHp <= 0)
        {
            greenEnemyCurrentHp = 0;
            print("I'm dead");
            greenEnemyDeadText.text = "I'm dead!";
            greenEnemyIsDead = true;
        }
    }
}
