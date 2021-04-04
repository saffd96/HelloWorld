using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform spawn;
    [SerializeField]
    private GameObject greenEnemyPrefab;
    [SerializeField]
    private GreenPlayer greenPlayer;

    private GameObject greenEnemy;

    [SerializeField]
    private string[] enemyNames = new string[10];

    [SerializeField]
    private Sprite[] enemySprites = new Sprite[10];

    [SerializeField]
    private int numberOfEnemies;

    private Sprite sprite;
    private int count = 0;

    void Awake()
    {

    }
    void Start()
    {

    }

    void Update()
    {
        if (count < numberOfEnemies && greenEnemy.GetComponent<GreenEnemy>().greenEnemyIsDead == true)
        {
            CreateAnEnemy();
            count++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            CreateAnEnemy();
        }
    }
    void CreateAnEnemy()
    {
        greenEnemy = Instantiate(greenEnemyPrefab, spawn.position, spawn.rotation);

        greenEnemy.GetComponent<GreenEnemy>().greenEnemyCurrentName = $"Green {enemyNames[count]}";
        greenEnemy.GetComponent<SpriteRenderer>().sprite = enemySprites[count];
        greenEnemy.GetComponent<GreenEnemy>().greenEnemyCurrentAttack = Random.Range(14, 24);
        greenEnemy.GetComponent<GreenEnemy>().greenEnemyCurrentPierce = Random.Range(16, 25);
        greenEnemy.GetComponent<GreenEnemy>().greenEnemyCurrentHp = Random.Range(180, 220);
        greenEnemy.GetComponent<GreenEnemy>().greenPlayer = greenPlayer;

        greenPlayer.GetComponent<GreenPlayer>().greenEnemy = greenEnemy;
    }
    void DestroyEnemy()
    {
        Destroy(greenEnemy);
    }
}
