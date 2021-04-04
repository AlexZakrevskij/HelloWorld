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
    public bool cycleFigth;
    public GreenEnemy mob;

    // Start is called before the first frame update

    void Start()
    {
        cycleFigth = false;
        print("Для начала боя нажмите ENTER");
        iconNum = 0;
        tmpCount = enemyCount;
        InvokeRepeating("Fight", 0, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hero.SetPlayerInfo();
            mob.SetEnemyInfo();
            mob.spriteRenderer.sprite = mob.enemySprite;
            Start();
        }
    }

    public void MakeAttack()
    {
        if (hero.playerHealth > 0 && enemyCount > 0)
        {
            hero.PlayerAttack();
            UpdateAfterAttack(mob.enemyHealth, 1);
            mob.EnemyAttack();
            UpdateAfterAttack(hero.playerHealth, 2);
        }
        if (hero.playerHealth <= 0 || enemyCount <= 0)
        {
            cycleFigth = true;
            //CancelInvoke("MakeAttack");
            GameOver(cycleFigth);
        }
    }

    void Fight()
    {
        if (cycleFigth == false)
        {
            MakeAttack();
        }
        else
        {
            CancelInvoke("Fight");
            cycleFigth = true;
            GameOver(cycleFigth);
        }
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
                if (hp <= 0)
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
                        cycleFigth = true;
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
                if (hp <= 0)
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
        if (endall)
        {
            print($"Все враги побеждены, {hero.playerName} победил в бою!");
            print("Нажмите ПРОБЕЛ для продолжения");
            CancelInvoke("Fight");
            Update();
        }
    }

    void PLayerHeal()
    {
        hero.playerHealth += hero.selfHeal;
        hero.playerTextMesh.text = $"Имя: {hero.playerName}\nЗдоровье: {hero.playerHealth}";
    }
}