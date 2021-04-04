using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayer : MonoBehaviour
{
    //Переменные закрытые от Юнити
    private string tpmPlayerName;
    private int tpmPlayerHealth;
    private int tpmPlayerDamage;
    private int tpmPlayerArmor;
    private int tpmSelfHeal;
    
    //Переменные для правки внутри Юнити
    public string playerName;
    public int playerHealth;
    public int selfHeal;
    public int playerDamage;
    public int playerArmor;
    public SpriteRenderer spriteRenderer;
    public Sprite playerSprite;
    public MeshRenderer meshRenderer;
    public TextMesh playerTextMesh;

    public GreenEnemy badGuy;
    // Start is called before the first frame update
    private void Start()
    {
        GetPlayerInfo();
        SetPlayerInfo();
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    public void SetPlayerInfo()
    {
        playerName = tpmPlayerName; 
        playerHealth = tpmPlayerHealth; 
        playerDamage = tpmPlayerDamage; 
        playerArmor = tpmPlayerArmor;
        selfHeal = tpmSelfHeal;
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

   

    private void GetPlayerInfo()
    {
    tpmPlayerName  = playerName;
    tpmPlayerHealth = playerHealth;
    tpmPlayerDamage = playerDamage;
    tpmPlayerArmor = playerArmor;
    tpmSelfHeal = selfHeal;
    }
}
