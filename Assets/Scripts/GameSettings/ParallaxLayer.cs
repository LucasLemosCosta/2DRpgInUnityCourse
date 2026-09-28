using System;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{

    [Range(0,1)][SerializeField] private float speedMultiplier;
    [SerializeField] private Transform background;


    public void MoveBackground(float distance)
    {
        background.position += Vector3.right * distance * speedMultiplier;
    }

    
}
