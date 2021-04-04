using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public int enemyCount;
    private int tmpCount;
    private int iconNum;
    public GreenPlayer hero;
    public bool cycleFigth = false;
    public GreenEnemy mob;
    /*private KeyCode playerCode = KeyCode.S;
    private KeyCode enemyCode = KeyCode.L;*/

    // Start is called before the first frame update

    void Start()
    {
        print("Для начала боя нажмите ENTER");
        iconNum = 0;
        tmpCount = enemyCount;
        Fight();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            /*iconNum = 0;
            tmpCount = enemyCount;
            Fight(); */   
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hero.SetPlayerInfo();
            mob.SetEnemyInfo();
            mob.spriteRenderer.sprite = mob.enemySprite;
            Start();
        }
    }
    /*public void PlayerMakeAttack(int enemies)
    {
        hero.PlayerAttack();
        UpdateAfterAttack(mob.enemyHealth, 1);
    }
    
    public void EnemyMakeAttack()
    {
        mob.EnemyAttack();
        UpdateAfterAttack(hero.playerHealth, 2);

    }*/
    public void MakeAttack()
    {
        if (hero.playerHealth > 0)
        {
            hero.PlayerAttack();
            UpdateAfterAttack(mob.enemyHealth, 1);    
        }
        if (enemyCount > 0)
        {
            mob.EnemyAttack();
            UpdateAfterAttack(hero.playerHealth, 2);    
        }

        
        if(hero.playerHealth <= 0)
        {
            cycleFigth = true;
            //CancelInvoke("MakeAttack");
            GameOver(cycleFigth);
        }
        if(enemyCount <= 0)
        {
            cycleFigth = true;
            //CancelInvoke("MakeAttack");
            GameOver(cycleFigth);
        }
    }
    void Fight()
    {
        if (!cycleFigth)
        {
             InvokeRepeating("MakeAttack",0,1.5f);
        }
        else
        {
            //cycleFigth = true;
            GameOver(cycleFigth);
        }
        /*if (enemyCount > 0 || !cycleFigth)
        {
            InvokeRepeating("MakeAttack",1.5F,1.5f);   
        }
        else
        {
            cycleFigth = true;
            GameOver(cycleFigth);
        }*/


    }

    private void KillingEnemy(int iNum)
    {
        mob.enemySprite = mob.mass[iNum];
        mob.spriteRenderer.sprite = mob.enemySprite;
    }
    private void UpdateAfterAttack(int hp, int num)
    {
        switch (num)
            {
                case 1:
                {
                    if (hp<=0)
                    {
                        mob.enemyTextMesh.text = $"Имя: {mob.enemyName} {tmpCount}\nСтатус: Мертв";
                        PLayerHeal();
                        tmpCount--;
                        iconNum++;
                        
                        if (tmpCount > 0)
                        {
                            KillingEnemy(iconNum);
                            mob.SetEnemyInfo();    
                        }
                        else
                        {
                            GameOver(cycleFigth);
                        }
                    }
                    else
                    {
                        mob.enemyTextMesh.text = $"Имя: {mob.enemyName} {tmpCount}\nЗдоровье: {hp}";
                    }
                }; break;
                case 2:
                {
                    if (hp<=0)
                    {
                        hero.playerTextMesh.text = $"Имя: {hero.playerName}\nСтатус: Мертв";
                    }
                    else
                    {
                        hero.playerTextMesh.text = $"Имя: {hero.playerName}\nЗдоровье: {hp}";
                    }
                }; break;
            }
    }
    private void GameOver(bool endall)
    {
        if (endall == true)
        {
            CancelInvoke("MakeAttack");
                
        }
        print($"Все враги побеждены, {hero.playerName} победил в бою!");
        print("Нажмите ПРОБЕЛ для продолжения");
        Start();
    }

    void PLayerHeal()
    {
        hero.playerHealth += hero.selfHeal;
        hero.playerTextMesh.text = $"Имя: {hero.playerName}\nЗдоровье: {hero.playerHealth}";
    }
}
