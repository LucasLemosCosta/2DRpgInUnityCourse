using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private ParallaxLayer[] layers;
    private Camera mainCamera;
    private float lastPosition;

    void Awake()
    {
        mainCamera = Camera.main;
        lastPosition = mainCamera.transform.position.x;
    }

    void Update()
    {
        float currentPosition = mainCamera.transform.position.x;
        float distance = currentPosition - lastPosition;
        lastPosition = currentPosition;

        foreach(ParallaxLayer background in layers)
        {
            background.MoveBackground(distance);
        }
    }




}
