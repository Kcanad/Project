using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();


    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;
            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }

        }
        else if(_hearts.Count > value && _hearts.Count !=0)
        {
            int deleteHealt = _hearts.Count - value;
            for (int i = 0; i < deleteHealt; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
        
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}