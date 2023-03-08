using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour 
{
    //Create Damage Popup
    public static DamagePopup Create(Vector2 position, bool isPlayer, int value, bool isCriticalHit, bool isHealing)
    {
        position.y += 0.5f;
        Transform damagePopupTransform = Instantiate(GameAssets.instance.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(value, isPlayer, isCriticalHit, isHealing);

        return damagePopup;
    }

    private static int sortingOrder;

    private const float DISSAPEAR_TIMER_MAX = 1f;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;
    private Vector3 moveVector;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int value, bool isPlayer, bool isCriticalHit, bool isHealing)
    {
        textMesh.SetText(value.ToString());
        if(isCriticalHit)
        {
            //Critical Hits
            textMesh.fontSize = 45;
            textColor = new Color(1f, 0f, 0f);
        }
        else if(isHealing)
        {
            //Healing
            textMesh.fontSize = 36;
            textColor = new Color(0, 1f, 0f);
        }
        else
        {
            textMesh.fontSize = 36;
            textColor = new Color(1f, 0.4666667f, 0f);
        }

        textMesh.color = (Color32)textColor;
        disappearTimer = DISSAPEAR_TIMER_MAX;

        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

        if(isPlayer)
        {
            moveVector = new Vector2(0.1f, 0.1f) * 60f;
        }
        else
        {
            moveVector = new Vector2(-0.1f, 0.1f) * 60f;
        }
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if(disappearTimer > DISSAPEAR_TIMER_MAX * 0.5f)
        {
            //First half of popup lifetime
            float increaseScaleAmount = 0.1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            //Second half of the popup lifetime
            float decreaseScaleAmount = 0.1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            //start disappearing
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
