using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    //Переменные закрытые от Юнити
    private string tpmEnemyName;
    private int tpmEnemyHealth;
    private int tpmEnemyDamage;
    private int tpmEnemyPierce;
    
    //Переменные для правки внутри Юнити
    public string enemyName;
    public int enemyHealth;
    public int enemyPierce;
    public int enemyDamage;
    
    public Sprite enemySprite;
    public SpriteRenderer spriteRenderer;
    public MeshRenderer meshRenderer;
    public TextMesh enemyTextMesh;

    public RedPlayer goodGuy;
    // Start is called before the first frame update
    private void Start()
    {
        GetEnemyInfo();
        SetEnemyInfo();
        spriteRenderer.sprite = enemySprite;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            EnemyAttack();
            UpdateAfterAttack(goodGuy.playerHealth);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetEnemyInfo();
            goodGuy.SetPlayerInfo();
        }
    }
    public void SetEnemyInfo()
    {
        enemyName = tpmEnemyName; 
        enemyHealth = tpmEnemyHealth; 
        enemyDamage = tpmEnemyDamage;
        enemyPierce = tpmEnemyPierce;
        enemyTextMesh.text = $"Имя: {tpmEnemyName}\nЗдоровье: {tpmEnemyHealth}";
    }
    public void EnemyAttack()
    {
        int damage = (tpmEnemyDamage + tpmEnemyPierce) - goodGuy.playerArmor;
        if (damage > 0)
        {
            goodGuy.playerHealth -= damage; 
            print($"{tpmEnemyName} атаковал {goodGuy.playerName} и нанес {damage} урона,  у {goodGuy.playerName} осталось {goodGuy.playerHealth} после этой атаки"); 
        }
        else
        {
            damage = 0;
            goodGuy.playerHealth -= damage;
            print($"{tpmEnemyName} не нанес {goodGuy.playerName} урона во время атаки"); 
        }
        
    }

    public void UpdateAfterAttack(int hp)
    {
        if (hp<=0)
        {
            goodGuy.playerTextMesh.text = $"Имя: {goodGuy.playerName}\nСтатус: Мертв";
            GameOver();
        }
        else
        {
            goodGuy.playerTextMesh.text = $"Имя: {goodGuy.playerName}\nЗдоровье: {hp}";
        }
    }
    public void GameOver()
    {
        print($"{tpmEnemyName} убит, {goodGuy.playerName} победил в бою!");
        print("Нажмите ПРОБЕЛ для продолжения");
    }

    private void GetEnemyInfo()
    {
        tpmEnemyName  = enemyName;
        tpmEnemyHealth = enemyHealth;
        tpmEnemyDamage = enemyDamage;
        tpmEnemyPierce = enemyPierce;
    }
}
