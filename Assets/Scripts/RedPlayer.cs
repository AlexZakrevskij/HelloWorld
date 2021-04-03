using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RedPlayer : MonoBehaviour
{
    
    //Переменные закрытые от Юнити
    private string tpmPlayerName;
    private int tpmPlayerHealth;

    private int tpmPlayerDamage;
    private int tpmPlayerArmor;
    
    //Переменные для правки внутри Юнити
    public string playerName;
    public int playerHealth;

    public int playerDamage;
    public int playerArmor;
    public SpriteRenderer spriteRenderer;
    public Sprite playerSprite;
   // public MeshRenderer meshRenderer;
    public TextMesh playerTextMesh;

    public RedEnemy badGuy;
    // Start is called before the first frame update
    private void Start()
    {
        GetPlayerInfo();
        SetPlayerInfo();
        spriteRenderer.sprite = playerSprite;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerAttack();
            UpdateAfterAttack(badGuy.enemyHealth);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetPlayerInfo();
            badGuy.SetEnemyInfo();
        }
    }

    public void SetPlayerInfo()
    {
        playerName = tpmPlayerName; playerHealth = tpmPlayerHealth; playerDamage = tpmPlayerDamage; playerArmor = tpmPlayerArmor;
        playerTextMesh.text = $"Имя: {tpmPlayerName}\nЗдоровье: {tpmPlayerHealth}";
    }

    public void PlayerAttack()
    {
        int damage = tpmPlayerDamage;
        if (damage > 0)
        {
            badGuy.enemyHealth -= damage; 
            print($"{tpmPlayerName} атаковал {badGuy.enemyName} и нанес {damage} урона, у {badGuy.enemyName} осталось {badGuy.enemyHealth} здоровья после атаки"); 
        }
        else
        {
            damage = 0;
            badGuy.enemyHealth -= damage; 
            print($"{tpmPlayerName} атаковал {badGuy.enemyName} и не нанес урона, {badGuy.enemyName} не потерял здоровье после атаки"); 
        }
        
    }

    public void UpdateAfterAttack(int hp)
    {
        if (hp<=0)
        {
            badGuy.enemyTextMesh.text = $"Имя: {badGuy.enemyName}\nСтатус: Умер";
            GameOver();
        }
        else
        {
            badGuy.enemyTextMesh.text = $"Имя: {badGuy.enemyName}\nЗдоровье: {hp}";
        }
    }

    public void GameOver()
    {
        print($"{tpmPlayerName} убил {badGuy.enemyName} и победил в этом бою!");
        print("Нажмите ПРОБЕЛ для продолжения");
    }

    private void GetPlayerInfo()
    {
    tpmPlayerName  = playerName;
    tpmPlayerHealth = playerHealth;
    tpmPlayerDamage = playerDamage;
    tpmPlayerArmor = playerArmor;
    }
    
}
