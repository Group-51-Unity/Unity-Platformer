using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlash : MonoBehaviour
{

    public Material healMaterial;
    public Material invulnerableMaterial;
    private float playerinvulnerableDuration;
    private SpriteRenderer _spriterenderer;
    private Material originalMaterial;
    private Coroutine invulnerableRoutine;
    private PlayerHealth _playerhealth;
    private Coroutine HealFlashRoutine;

    void Start()
    {

        _spriterenderer = GetComponent<SpriteRenderer>();
        _playerhealth = GetComponent<PlayerHealth>();
        originalMaterial = _spriterenderer.material;
        playerinvulnerableDuration = _playerhealth.invulnerableSeconds;
    }


    public void Flash()
    {
        if (invulnerableRoutine != null)
        {
            StopCoroutine(invulnerableRoutine);
        }
        invulnerableRoutine = StartCoroutine(FlashRoutine());
    }

    public void FlashHeal()
    {
        if(HealFlashRoutine != null)
        {
            StopCoroutine(HealFlashRoutine);
        }
        HealFlashRoutine = StartCoroutine(HealFlashCoRoutine());
    }
    private IEnumerator HealFlashCoRoutine()
    {
        _spriterenderer.material = healMaterial;
        yield return new WaitForSeconds(0.5f);
        _spriterenderer.material = originalMaterial;
        HealFlashRoutine = null;
    }

    private IEnumerator FlashRoutine()
    {
        _spriterenderer.material = invulnerableMaterial;
        yield return new WaitForSeconds(playerinvulnerableDuration);
        _spriterenderer.material = originalMaterial;
        invulnerableRoutine = null;
    }

}

