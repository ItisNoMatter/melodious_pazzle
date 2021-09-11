using UnityEngine;
using System.Collections;

public class AspectCamera : MonoBehaviour
{
    public Vector2 maxAspect = new Vector2();
    public Vector2 minAspect = new Vector2();
    private Camera came;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Awake()
    {
        came = GetComponent<Camera>();
        //インスペクタ最大値と最長値をそれぞれ設定
        //同じ値にするとアスペクト比は固定される
        Vector2 targetAspect = GetTargetAspect();

        //未設定だったり、変更する必要がなければスルー
        if (targetAspect != Vector2.zero)
        {
            Rect rect = CalcAspect(targetAspect);
            came.rect = rect;
        }
    }

    private Vector2 GetTargetAspect()
    {
        if (Screen.width > Screen.height)
        {
            float screenAspect = (float)Screen.width / (float)Screen.height;
            if (screenAspect < minAspect.x / minAspect.y)
            {
                return minAspect;
            }
            else if (screenAspect > maxAspect.x / maxAspect.y)
            {
                return maxAspect;
            }
        }
        else
        {
            float screenAspect = (float)Screen.height / (float)Screen.width;
            if (screenAspect < minAspect.y / minAspect.x)
            {
                return minAspect;
            }
            else if (screenAspect > maxAspect.y / maxAspect.x)
            {
                return maxAspect;
            }
        }
        //ここを通った場合調整の必要なし
        return Vector2.zero;
    }

    private Rect CalcAspect(Vector2 targetAspect)
    {
        float targetRate = targetAspect.x / targetAspect.y;
        float screenRate = (float)Screen.width / (float)Screen.height;
        float scaleHeight = screenRate / targetRate;
        Rect rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
        if (1.0f > scaleHeight)
        {
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            rect.width = 1.0f;
            rect.height = scaleHeight;
        }
        else
        {
            float scale_width = 1.0f / scaleHeight;
            rect.x = (1.0f - scale_width) / 2.0f;
            rect.y = 0.0f;
            rect.width = scale_width;
            rect.height = 1.0f;
        }
        return rect;
    }
}