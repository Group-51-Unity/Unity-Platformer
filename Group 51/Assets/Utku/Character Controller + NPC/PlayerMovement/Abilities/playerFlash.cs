using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlash : MonoBehaviour
{


    public Material invulnerableMaterial;
    private float playerinvulnerableDuration;
    private SpriteRenderer _spriterenderer;
    private Material originalMaterial;
    private Coroutine invulnerableRoutine;
    private PlayerHealth _playerhealth;


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

    private IEnumerator FlashRoutine()
    {
        _spriterenderer.material = invulnerableMaterial;
        yield return new WaitForSeconds(playerinvulnerableDuration);
        _spriterenderer.material = originalMaterial;
        invulnerableRoutine = null;
    }

}

