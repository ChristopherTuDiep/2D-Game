using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowBar : MonoBehaviour
{
    private float maxHP, currentHP, drainHP;
    private float damage;
    private float time;
    private bool healing;
    public Slider barFast, barSlow;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100f;
        currentHP = maxHP;
        drainHP = maxHP;

        barFast.maxValue = maxHP;
        barFast.value = maxHP;

        barSlow.maxValue = maxHP;
        barSlow.value = maxHP;

        damage = 10f;
        healing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(drainHP > currentHP && !healing)
        {
            drainHP = Mathf.Lerp(drainHP, currentHP, time);
            time += 1.0f * Time.deltaTime;
        }
        else if(drainHP > currentHP && healing)
        {
            currentHP = Mathf.Lerp(currentHP, drainHP, time);
            time += 0.1f * Time.deltaTime;
        }

        barFast.value = currentHP;
        barSlow.value = drainHP;

        if (currentHP == drainHP)
        {
            healing = false;
        }

    }

    public void TakeDamage()
    {
        currentHP -= damage;
        time = 0f;
    }

    public void RegainHealth()
    {
        drainHP += damage;
        time = 0f;
        healing = true;
    }
}
