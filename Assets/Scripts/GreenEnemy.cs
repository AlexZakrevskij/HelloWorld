using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{ 
    //Переменные закрытые от Юнити
    private string tpmEnemyName;
    private int tpmEnemyHealth;
    private int tpmEnemyDamage;
    private int tpmEnemyPierce;
    private Sprite tpmEnemySprite;
    
    //Переменные для правки внутри Юнити
    public string enemyName;
    public int enemyHealth;
    public int enemyPierce;
    public int enemyDamage;
    public Sprite[] mass;
    public SpriteRenderer spriteRenderer;
    public MeshRenderer meshRenderer;
    public TextMesh enemyTextMesh;
    public Sprite enemySprite;

    public GreenPlayer goodGuy;
    
    private void Start()
    {
        GetEnemyInfo();
        SetEnemyInfo();
    }
    private void Update()
    {

    }
    public void SetEnemyInfo()
    {
        enemyName = tpmEnemyName; 
        enemyHealth = tpmEnemyHealth; 
        enemyDamage = tpmEnemyDamage;
        enemyPierce = tpmEnemyPierce;
        enemyTextMesh.text = $"Имя: {tpmEnemyName}\nЗдоровье: {tpmEnemyHealth}";
        
        enemySprite = tpmEnemySprite;
        //spriteRenderer.sprite = enemySprite;
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
    

    private void GetEnemyInfo()
    {
        tpmEnemyName  = enemyName;
        tpmEnemyHealth = enemyHealth;
        tpmEnemyDamage = enemyDamage;
        tpmEnemyPierce = enemyPierce;
        tpmEnemySprite = enemySprite;
    }
}
