using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    void Start()
    {
        // Creează Canvas
        GameObject canvasGO = new GameObject("CrosshairCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Creează Image pentru punct
        GameObject crosshairGO = new GameObject("Crosshair");
        crosshairGO.transform.SetParent(canvasGO.transform);

        Image crosshairImage = crosshairGO.AddComponent<Image>();

        // Creează un sprite simplu alb (punct) folosind un pixel alb
        Texture2D tex = new Texture2D(1,1);
        tex.SetPixel(0,0,Color.white);
        tex.Apply();
        Sprite sprite = Sprite.Create(tex, new Rect(0,0,1,1), new Vector2(0.5f,0.5f));
        crosshairImage.sprite = sprite;

        // Setează dimensiunea imaginii mici (ex: 10x10 pixeli)
        RectTransform rect = crosshairGO.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(10, 10);
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = Vector2.zero;
    }
}
