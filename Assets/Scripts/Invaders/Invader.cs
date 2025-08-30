using System;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public InvaderData invaderData; // Scriptable Object referansı

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    public Action<int> _killed;

    void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() 
    {
        InvokeRepeating(nameof(AnimateSprite), invaderData.animationTime, invaderData.animationTime);    
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= invaderData.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = invaderData.animationSprites[_animationFrame];
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this._killed.Invoke(this.invaderData.score);
            gameObject.SetActive(false);
        }
    }
}