using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public CreatureData playerData;
    public CreatureData enemyData;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerData(CreatureData data)
    {
        playerData = data;
    }

    public void SetEnemyData(CreatureData data)
    {
        enemyData = data;
    }

    public void PlayerAttack()
    {
        int damage = CalculateDamage(playerData.animalData);
        enemyData.animalData.healthMultiplier -= damage;

        if (enemyData.animalData.healthMultiplier <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            EnemyTurn();
        }
    }

    public void PlayerDefend()
    {
        int reducedDamage = CalculateDamage(enemyData.animalData) / 2;
        playerData.animalData.healthMultiplier -= reducedDamage;

        if (playerData.animalData.healthMultiplier <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void EnemyTurn()
    {
        int damage = CalculateDamage(enemyData.animalData);
        playerData.animalData.healthMultiplier -= damage;

        if (playerData.animalData.healthMultiplier <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public bool TryEscape()
    {
        return Random.value > 0.5f;
    }

    int CalculateDamage(Animal animal)
    {
        return Random.Range(animal.minAttack, animal.maxAttack);
    }
}