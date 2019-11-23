using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite[] _sprites;
    [SerializeField]
    float _animationFPS;
    [SerializeField]
    SpriteRenderer _target;

    protected Sprite[] Sprites
    {
        get
        {
            return _sprites;
        }

        set
        {
            _sprites = value;
        }
    }

    private void Start()
    {
        _target = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float _divider = 1 / _animationFPS;
        _target.sprite = _sprites[Mathf.FloorToInt(Time.time / _divider) % _sprites.Length];
    }
}
