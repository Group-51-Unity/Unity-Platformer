using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlash : MonoBehaviour
{


    public Material flashMaterial;
    public float flashDuration;
    private SpriteRenderer _spriterenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;



    void Start()
    {

        _spriterenderer = GetComponent<SpriteRenderer>();
        originalMaterial = _spriterenderer.material;
    }


    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        _spriterenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        _spriterenderer.material = originalMaterial;
        flashRoutine = null;
    }

}
