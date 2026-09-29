using System;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{

    [Range(0, 1)][SerializeField] private float speedMultiplier;
    [SerializeField] private Transform background;

    private float imageSize;
    private float imageHalf;


    public void MoveBackground(float distance)
    {
        background.position += Vector3.right * distance * speedMultiplier;
    }

    public void LoopBackGround(float rightCameraEdge,float leftCameraEdge)
    {
        float rightImageEdge = background.position.x + imageHalf;
        float leftImageEdge = background.position.x - imageHalf;

        if(rightImageEdge < leftCameraEdge)
        {
            background.position += Vector3.right * imageSize;
        }
        else if(leftImageEdge > rightCameraEdge)
        {
            background.position += Vector3.right * -imageSize;
        }


  
    }
    public void CalculateImageSize()
    {
        imageSize = background.GetComponent<SpriteRenderer>().bounds.size.x;
        imageHalf = imageSize/2;
    }








}
