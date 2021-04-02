using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    [SerializeField]
    private TextMesh redEnemyNameText;
    [SerializeField]
    private TextMesh redEnemyHpText;
    [SerializeField]
    private TextMesh redEnemyDeadText;
    [SerializeField]
    private TextMesh debugText;

    [SerializeField]
    private RedPlayer redPlayer;

    [SerializeField]
    private string redEnemyName;

    [SerializeField]
    private int redEnemyAttack;
    [SerializeField]
    private int redEnemyHp;
    [SerializeField]
    private int redEnemyPierce;

    private int redEnemyTempHp;
    private int redEnemyTempAttack;
    private int redEnemyTempPierce;

    private string redEnemyTempName;

    public int redEnemyCurrentHp;
    public int redEnemyCurrentAttack;
    public int redEnemyCurrentPierce;

    public string redEnemyCurrentName;

    private bool redEnemyIsDead;

    private void Awake()
    {
        redEnemyTempHp = redEnemyHp;
        redEnemyTempAttack = redEnemyAttack;
        redEnemyTempPierce = redEnemyPierce;
        redEnemyTempName = redEnemyName;
    }

    private void Start()
    {
        redEnemyCurrentHp = redEnemyTempHp;
        redEnemyCurrentAttack = redEnemyTempAttack;
        redEnemyCurrentPierce = redEnemyTempPierce;
        redEnemyCurrentName = redEnemyTempName;
        debugText.text = null;
        redEnemyIsDead = false;
    }

    private void Update()
    {
        UpdateInfo();
        CheckKey();
    }

    public void GetDamage(int damageValue)
    {
        if (redEnemyIsDead == false)
        {
            if (damageValue > 0)
            {
                redEnemyCurrentHp -= damageValue;
                print($"{redPlayer.name} ударил {redEnemyCurrentName} и нанес {damageValue} урона." +
                    $"\nУ {redPlayer.name} осталось {redPlayer.redPlayerCurrentHp}" +
                    $"\nУ {redEnemyCurrentName} осталось {redEnemyCurrentHp}");
                debugText.text = $"{redPlayer.name} ударил {redEnemyCurrentName} и нанес {damageValue} урона." +
                    $"\nУ {redPlayer.name} осталось {redPlayer.redPlayerCurrentHp}" +
                    $"\nУ {redEnemyCurrentName} осталось {redEnemyCurrentHp}";
            }
            else
            {
                print($"{redPlayer.name} ударил {redEnemyCurrentName} и не нанес урона." +
                    $"\nУ {redPlayer.name} осталось {redPlayer.redPlayerCurrentHp}" +
                    $"\nУ {redEnemyCurrentName} осталось {redEnemyCurrentHp}");
                debugText.text = $"{redPlayer.name} ударил {redEnemyCurrentName} и не нанес урона." +
                    $"\nУ {redPlayer.name} осталось {redPlayer.redPlayerCurrentHp}" +
                    $"\nУ {redEnemyCurrentName} осталось {redEnemyCurrentHp}";
            }
        }
    }

    public void UpdateInfo()
    {
        redEnemyNameText.text = redEnemyCurrentName;
        redEnemyHpText.text = redEnemyCurrentHp.ToString();
        if (redEnemyCurrentHp <= 0)
        {
            print("I'm dead");
            redEnemyCurrentHp = 0;
            redEnemyDeadText.text = "I'm dead!";
            redEnemyIsDead = true;
        }
    }

    public void CheckKey()
    {
        if (Input.GetKeyDown(KeyCode.L) && redEnemyIsDead == false)
        {
            redPlayer.GetDamage(redEnemyCurrentAttack, redEnemyCurrentPierce);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Start();
        }
    }
}
