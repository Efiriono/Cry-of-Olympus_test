using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimal", menuName = "Creatures/Animal", order = 51)]
public class Animal : Creature
{
    public float attackMultiplier;
    public float defenseMultiplier;
    public float healthMultiplier;

    public int currentHealth;

    private void OnEnable()
    {
        CalculateStats();
    }

    private void CalculateStats()
    {
        float multiplier = GetMultiplierByTier(tier);

        attackMultiplier = CalculateMultiplier(minAttack, maxAttack, multiplier);
        defenseMultiplier = CalculateMultiplier(minDefense, maxDefense, multiplier);
        healthMultiplier = CalculateMultiplier(minHealth, maxHealth, multiplier);

        currentHealth = Mathf.RoundToInt(healthMultiplier);
    }

    private float CalculateMultiplier(int minValue, int maxValue, float multiplier)
    {
        float baseValue = Random.Range(minValue, maxValue);
        return (baseValue + 0.1f * level) * multiplier;
    }

    private float GetMultiplierByTier(int tier)
    {
        switch (tier)
        {
            case 1: return 1.0f;
            case 2: return 1.2f;
            case 3: return 1.4f;
            case 4: return 2.0f;
            default: return 1.0f;
        }
    }
}