using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private Transform gear;

    // Start is called before the first frame update
    void Start()
    {
        gear.DOMoveX(-3.2f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
    }
}