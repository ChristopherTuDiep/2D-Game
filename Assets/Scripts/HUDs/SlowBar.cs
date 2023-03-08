using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowBar : MonoBehaviour
{
    private float maxHP, currentHP, drainHP;
    private float damage;
    private float time;
    public Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100f;
        currentHP = maxHP;
        drainHP = maxHP;

        bar.maxValue = maxHP;
        bar.value = maxHP;

        damage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(drainHP != currentHP)
        {
            drainHP = Mathf.Lerp(drainHP, currentHP, time);
            time += 1.0f * Time.deltaTime;
        }

        bar.value = drainHP;
    }

    public void TakeDamage()
    {
        currentHP -= damage;
        time = 0f;
    }

    public void RegainHealth()
    {
        currentHP += damage;
        time = 0f;
    }
}
