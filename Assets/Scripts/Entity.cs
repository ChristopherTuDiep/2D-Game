using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Entity
{
    string entityName { get; set; }
    int entityLevel { get; set; }
    bool isPlayerEntity { get; set; }

    int maxHealth { get; set; }
    int currentHealth { get; set; }

    int strength { get; set; }
    int magic { get; set; }
    int endurance { get; set; }
    int agility { get; set; }

    public bool isCurrentTurn { get; set; }
    List<Skill> skills { get; set; }
    bool isDead { get; set; }
    public void IsCurrentTurn();
    public void TurnEnded();
    public bool Hit();
    public float WeaponDamage();
    public void TakeDamage(int damage);
    public Skill UseSkill(string skillName);
    public bool Heal(int healing);
    public void UpdateHUD();
}
