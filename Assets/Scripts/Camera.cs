using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float referenceWidth = 10f; // Szeroko�� �wiata, kt�r� chcesz widzie� na referencyjnej rozdzielczo�ci
    public float referenceHeight = 10f; // Wysoko�� �wiata

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("CameraScaler requires a Camera component.");
            return;
        }

        // Ustaw kamer� ortograficzn�
        cam.orthographic = true;

        AdjustCamera();
    }

    void AdjustCamera()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float referenceAspectRatio = referenceWidth / referenceHeight;

        if (currentAspectRatio >= referenceAspectRatio)
        {
            // Ekran jest szerszy ni� referencyjne proporcje, dopasuj do wysoko�ci
            cam.orthographicSize = referenceHeight / 2f;
        }
        else
        {
            // Ekran jest w�szy ni� referencyjne proporcje, dopasuj do szeroko�ci
            // Oblicz now� wysoko��, aby szeroko�� pasowa�a
            cam.orthographicSize = (referenceWidth / currentAspectRatio) / 2f;
        }
    }

    // Mo�esz wywo�a� to w Start() lub OnEnable() je�li chcesz, aby dostosowanie by�o jednorazowe
    // lub w Update() je�li chcesz, aby kamera dynamicznie reagowa�a na zmian� rozmiaru okna (mniej typowe dla gier mobilnych)
    void Start()
    {
        AdjustCamera();
    }
}