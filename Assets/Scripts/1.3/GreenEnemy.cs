using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    [SerializeField]
    private int numberOfEnemies;
    [SerializeField]
    private GreenEnemy greenEnemy;

    [SerializeField]
    private TextMesh greenEnemyNameText;
    [SerializeField]
    private TextMesh greenEnemyHpText;
    [SerializeField]
    private TextMesh greenEnemyDeadText;
    [SerializeField]
    private TextMesh debugText;

    [SerializeField]
    private GreenPlayer greenPlayer;

    [SerializeField]
    private string greenEnemyName;

    [SerializeField]
    private int greenEnemyAttack;
    [SerializeField]
    private int greenEnemyHp;
    [SerializeField]
    private int greenEnemyPierce;

    private int greenEnemyTempHp;
    private int greenEnemyTempAttack;
    private int greenEnemyTempPierce;

    private string greenEnemyTempName;

    public int greenEnemyCurrentHp;
    public int greenEnemyCurrentAttack;
    public int greenEnemyCurrentPierce;

    public string greenEnemyCurrentName;

    private bool greenEnemyIsDead;

    private void Awake()
    {
        GreenEnemy[] enemies = new GreenEnemy[numberOfEnemies];

        print(enemies.Length);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(greenEnemy);
            print(i);
        }

        greenEnemyTempHp = greenEnemyHp;
        greenEnemyTempAttack = greenEnemyAttack;
        greenEnemyTempPierce = greenEnemyPierce;
        greenEnemyTempName = greenEnemyName;
    }

    private void Start()
    {
        greenEnemyCurrentHp = greenEnemyTempHp;
        greenEnemyCurrentAttack = greenEnemyTempAttack;
        greenEnemyCurrentPierce = greenEnemyTempPierce;
        greenEnemyCurrentName = greenEnemyTempName;
        debugText.text = null;
        greenEnemyDeadText.text = null;
        greenEnemyIsDead = false;
    }

    private void Update()
    {
        UpdateInfo();
        CheckKey();
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

    public void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.L) && greenEnemyIsDead == false)
        {
            greenPlayer.GetDamage(greenEnemyCurrentAttack, greenEnemyCurrentPierce);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Start();
        }
    }
}
