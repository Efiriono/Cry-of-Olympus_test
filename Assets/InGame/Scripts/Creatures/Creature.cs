using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : ScriptableObject
{
    public string creatureName;
    public string description;
    public int level;
    public int tier;
    public int minAttack;
    public int maxAttack;
    public int minDefense;
    public int maxDefense;
    public int minHealth;
    public int maxHealth;
    public Sprite creatureSprite;
}