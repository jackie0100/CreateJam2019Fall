using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCoins : MonoBehaviour
{
    [SerializeField]
    GameObject _coin;
    [SerializeField]
    float _amount;
    [SerializeField]
    float _direction;
    [SerializeField]
    float _angle;

    public void ThrowSomeCoins()
    {
        for (int i = 0; i < _amount; i++)
            GameObject.Instantiate(_coin, transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f)), Quaternion.identity);
    }
}
