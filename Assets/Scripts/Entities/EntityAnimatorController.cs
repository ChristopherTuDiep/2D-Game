using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimatorController : MonoBehaviour
{
    private Animator animation;
    private SpriteRenderer sprite;

    private void Start()
    {
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void BasicWeaponAttack()
    {
        animation.SetBool("weaponAttack", true);
    }

    public void PhysicalSkillAttack()
    {
        animation.SetBool("physicalSkill", true);
    }

    public void EndingOfAnimation()
    {
        animation.SetBool("weaponAttack", false);
        animation.SetBool("physicalSkill", false);
    }
}
