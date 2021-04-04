using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : MonoBehaviour
{
    [SerializeField]
    private TextMesh greenPlayerNameText;
    [SerializeField]
    private TextMesh greenPlayerHpText;
    [SerializeField]
    private TextMesh greenPlayerDeadText;
    [SerializeField]
    private TextMesh debugText;

    [SerializeField]
    private string greenPlayerName;

    [SerializeField]
    private int greenPlayerAttack;
    [SerializeField]
    private int greenPlayerHp;
    [SerializeField]
    private int greenPlayerDefence;
    [SerializeField]
    private int healAmount;

    public GreenEnemy greenEnemy;

    private int greenPlayerTempHp;
    private int greenPlayerTempAttack;
    private int greenPlayerTempDefence;

    private string greenPlayerTempName;

    public int greenPlayerCurrentHp;
    public int greenPlayerCurrentAttack;
    public int greenPlayerCurrentDefence;

    public string greenPlayerCurrentName;

    private bool greenPlayerIsDead;

    private void Awake()
    {
        greenPlayerTempName = greenPlayerName;
        greenPlayerTempHp = greenPlayerHp;
        greenPlayerTempAttack = greenPlayerAttack;
        greenPlayerTempDefence = greenPlayerDefence;
    }

    private void Start()
    {
        greenPlayerCurrentName = greenPlayerTempName;
        greenPlayerCurrentHp = greenPlayerTempHp;
        greenPlayerCurrentAttack = greenPlayerTempAttack;
        greenPlayerCurrentDefence = greenPlayerTempDefence;
        debugText.text = null;
        greenPlayerDeadText.text = null;
        greenPlayerIsDead = false;
    }

    private void Update()
    {
        UpdateInfo();
        CheckKey();
    }

    public void GetDamage(int damageValue, int pierce)
    {
        if (greenPlayerIsDead == false)
        {
            damageValue -= greenPlayerCurrentDefence - pierce;
            if (damageValue > 0)
            {
                greenPlayerCurrentHp -= damageValue;
                print($"{greenEnemy.name} ударил {greenPlayerName} и нанес {damageValue} урона. " +
                    $"У {greenEnemy.name} осталось {greenEnemy.greenEnemyCurrentHp}. " +
                    $"У {greenPlayerCurrentName} осталось {greenPlayerCurrentHp}");
                debugText.text = $"{greenEnemy.name} ударил {greenPlayerCurrentName} и нанес {damageValue} урона." +
                    $"\nУ {greenEnemy.name} осталось {greenEnemy.greenEnemyCurrentHp}" +
                    $"\nУ {greenPlayerCurrentName} осталось {greenPlayerCurrentHp}";
            }
            else
            {
                print($"{greenEnemy.name} ударил {greenPlayerCurrentName} и не нанес урона. " +
                    $"У {greenEnemy.name} осталось {greenEnemy.greenEnemyCurrentHp}. " +
                    $"У {greenPlayerCurrentName} осталось {greenPlayerCurrentHp}");
                debugText.text = $"{greenEnemy.name} ударил {greenPlayerCurrentName} и не нанес урона." +
                    $"\nУ {greenEnemy.name} осталось {greenEnemy.greenEnemyCurrentHp}" +
                    $"\nУ {greenPlayerCurrentName} осталось {greenPlayerCurrentHp}";
            }
        }
    }

    public void UpdateInfo()
    {
        greenPlayerNameText.text = greenPlayerCurrentName;
        greenPlayerHpText.text = greenPlayerCurrentHp.ToString();
        if (greenPlayerCurrentHp <= 0)
        {
            greenPlayerCurrentHp = 0;
            print("I'm dead");
            greenPlayerDeadText.text = "I'm dead!";
            greenPlayerIsDead = true;
        }
    }

    public void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.S) && greenPlayerIsDead == false)
        {
            greenEnemy.GetDamage(greenPlayerCurrentAttack);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Start();
        }
    }

    public void Heal()
    {
        greenPlayerCurrentHp += healAmount;
    }
}
