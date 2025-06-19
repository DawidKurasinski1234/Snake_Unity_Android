using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float referenceWidth = 10f; // Szerokoœæ œwiata, któr¹ chcesz widzieæ na referencyjnej rozdzielczoœci
    public float referenceHeight = 10f; // Wysokoœæ œwiata

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("CameraScaler requires a Camera component.");
            return;
        }

        // Ustaw kamerê ortograficzn¹
        cam.orthographic = true;

        AdjustCamera();
    }

    void AdjustCamera()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float referenceAspectRatio = referenceWidth / referenceHeight;

        if (currentAspectRatio >= referenceAspectRatio)
        {
            // Ekran jest szerszy ni¿ referencyjne proporcje, dopasuj do wysokoœci
            cam.orthographicSize = referenceHeight / 2f;
        }
        else
        {
            // Ekran jest wê¿szy ni¿ referencyjne proporcje, dopasuj do szerokoœci
            // Oblicz now¹ wysokoœæ, aby szerokoœæ pasowa³a
            cam.orthographicSize = (referenceWidth / currentAspectRatio) / 2f;
        }
    }

    // Mo¿esz wywo³aæ to w Start() lub OnEnable() jeœli chcesz, aby dostosowanie by³o jednorazowe
    // lub w Update() jeœli chcesz, aby kamera dynamicznie reagowa³a na zmianê rozmiaru okna (mniej typowe dla gier mobilnych)
    void Start()
    {
        AdjustCamera();
    }
}