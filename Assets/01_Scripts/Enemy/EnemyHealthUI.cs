using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Image frontBar;
    [SerializeField] private TextMeshProUGUI healthText;

    public void UpdateHealthUI(float baseHp, float curHp)
    {
        healthText.text = $"{curHp} / {baseHp}";

        float hpRate = curHp/baseHp;

        frontBar.rectTransform.localScale = new Vector3(hpRate, 1f, 1f);
    }
}
