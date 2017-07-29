using UnityEngine;

public class Wolf : AnimalController
{
    private BoxCollider _attackCollider;

    void Start()
    {
        _attackCollider = GetComponent<BoxCollider>();
    }
}