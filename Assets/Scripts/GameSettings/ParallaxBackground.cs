using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private ParallaxLayer[] layers;
    private Camera mainCamera;
    private float lastPosition;
    private float cameraSizeHalf;

    void Awake()
    {
        mainCamera = Camera.main;
        lastPosition = mainCamera.transform.position.x;

        cameraSizeHalf = mainCamera.aspect * mainCamera.orthographicSize;
        CalculateImagesSize();
    }

    void Update()
    {
        float currentPosition = mainCamera.transform.position.x;
        float distance = currentPosition - lastPosition;
        lastPosition = currentPosition;

        float rightCameraEdge = currentPosition + cameraSizeHalf;
        float leftCameraEdge = currentPosition - cameraSizeHalf;

        foreach(ParallaxLayer background in layers)
        {
            background.MoveBackground(distance);
            background.LoopBackGround(rightCameraEdge,leftCameraEdge);
        }
    }


    private void CalculateImagesSize()
    {
        foreach(ParallaxLayer background in layers)
        {
            background.CalculateImageSize();
        }
    }




}
