using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField]private int hitsRemaining;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateVisualState();
    }
    void Update()
    {

    }
    private void UpdateVisualState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(Color.white , Color.red, hitsRemaining/10f);
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        hitsRemaining --;
        if(hitsRemaining > 0)
        UpdateVisualState();
        else if (hitsRemaining <= 0)
        Destroy(gameObject);
    }
    internal void SetHit(int hits)
    {
        hitsRemaining = hits;
        UpdateVisualState();
    }
}
