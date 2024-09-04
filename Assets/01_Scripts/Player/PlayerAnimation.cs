using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Player player;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite attackSprite;

    public void EndInvincible()
    {
        player.Invincible = false;
    }

    public void ChangeAttackSprite()
    {
        StartCoroutine(ChangeSprite());
    }

    private IEnumerator ChangeSprite()
    {
        spriteRenderer.sprite = attackSprite;

        yield return new WaitForSeconds(player.playerAttackSpeed);

        spriteRenderer.sprite = idleSprite;
    }
}
