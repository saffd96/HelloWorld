using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    [SerializeField]
    private TextMesh redPlayerNameText;
    [SerializeField]
    private TextMesh redPlayerHpText;
    [SerializeField]
    private TextMesh redPlayerDeadText;
    [SerializeField]
    private TextMesh debugText;

    [SerializeField]
    private RedEnemy redEnemy;

    [SerializeField]
    private string redPlayerName;

    [SerializeField]
    private int redPlayerAttack;
    [SerializeField]
    private int redPlayerHp;
    [SerializeField]
    private int redPlayerDefence;

    private int redPlayerTempHp;
    private int redPlayerTempAttack;
    private int redPlayerTempDefence;

    private string redPlayerTempName;

    public int greenPlayerCurrentHp;
    public int redPlayerCurrentAttack;
    public int redPlayerCurrentDefence;

    public string redPlayerCurrentName;

    private bool redPlayerIsDead;

    private void Awake()
    {
        redPlayerTempName = redPlayerName;
        redPlayerTempHp = redPlayerHp;
        redPlayerTempAttack = redPlayerAttack;
        redPlayerTempDefence = redPlayerDefence;
    }

    private void Start()
    {
        redPlayerCurrentName = redPlayerTempName;
        greenPlayerCurrentHp = redPlayerTempHp;
        redPlayerCurrentAttack = redPlayerTempAttack;
        redPlayerCurrentDefence = redPlayerTempDefence;
        debugText.text = null;
        redPlayerDeadText.text = null;
        redPlayerIsDead = false;
    }

    private void Update()
    {
        UpdateInfo();
        CheckKey();
    }

    public void GetDamage(int damageValue, int pierce)
    {
        if (redPlayerIsDead == false)
        {
            damageValue -= redPlayerCurrentDefence - pierce;
            if (damageValue > 0)
            {
                greenPlayerCurrentHp -= damageValue;
                print($"{redEnemy.name} ударил {redPlayerName} и нанес {damageValue} урона. " +
                    $"У {redEnemy.name} осталось {redEnemy.greenEnemyCurrentHp}. " +
                    $"У {redPlayerCurrentName} осталось {greenPlayerCurrentHp}");
                debugText.text = $"{redEnemy.name} ударил {redPlayerCurrentName} и нанес {damageValue} урона." +
                    $"\nУ {redEnemy.name} осталось {redEnemy.greenEnemyCurrentHp}" +
                    $"\nУ {redPlayerCurrentName} осталось {greenPlayerCurrentHp}";
            }
            else
            {
                print($"{redEnemy.name} ударил {redPlayerCurrentName} и не нанес урона. " +
                    $"У {redEnemy.name} осталось {redEnemy.greenEnemyCurrentHp}. " +
                    $"У {redPlayerCurrentName} осталось {greenPlayerCurrentHp}");
                debugText.text = $"{redEnemy.name} ударил {redPlayerCurrentName} и не нанес урона." +
                    $"\nУ {redEnemy.name} осталось {redEnemy.greenEnemyCurrentHp}" +
                    $"\nУ {redPlayerCurrentName} осталось {greenPlayerCurrentHp}";
            }
        }
    }

    public void UpdateInfo()
    {
        redPlayerNameText.text = redPlayerCurrentName;
        redPlayerHpText.text = greenPlayerCurrentHp.ToString();
        if (greenPlayerCurrentHp <= 0)
        {
            greenPlayerCurrentHp = 0;
            print("I'm dead");
            redPlayerDeadText.text = "I'm dead!";
            redPlayerIsDead = true;
        }
    }

    public void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.S) && redPlayerIsDead == false)
        {
            redEnemy.GetDamage(redPlayerCurrentAttack);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Start();
        }
    }
}
