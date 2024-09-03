using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InfoUI : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;

    private InputAction mouseLeftClick;

    [SerializeField] private LayerMask enemyLayer;

    [Header("UI")]
    [SerializeField] private GameObject infoUI;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI gradeText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        mouseLeftClick = playerInputManager.MouseLeftClick;

        mouseLeftClick.performed += OnMouseLeftClick;
    }

    public void OnMouseLeftClick(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, enemyLayer);

        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                UpdateUI(enemy);
            }
        }
        else
        {
            infoUI.SetActive(false);
        }
    }

    private void UpdateUI(Enemy enemy)
    {
        EnemyInfo info = enemy.GetEnemyInfo();

        nameText.text = info.Name;
        gradeText.text = info.Grade;
        speedText.text = info.Speed.ToString();
        healthText.text = info.Health.ToString();

        infoUI.SetActive(true);
    }
}
