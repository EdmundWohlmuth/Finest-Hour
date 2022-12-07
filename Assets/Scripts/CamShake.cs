using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    bool isTweening = false;
    public Vector2 camStartPos;

    public void ShakeCameraStart()
    {
        isTweening = true;
        camStartPos = transform.position;
        LeanTween.moveY(gameObject, transform.position.y - 0.5f, 0.05f).setOnComplete(ShakeCamera2);
    }

    public void ShakeCamera2()
    {
        LeanTween.moveY(gameObject, transform.position.y + 0.3f, 0.08f).setOnComplete(ShakeCamera3);
    }

    public void ShakeCamera3()
    {
        LeanTween.moveX(gameObject, transform.position.x + 0.5f, 0.1f).setOnComplete(ShakeCamera4);
    }

    public void ShakeCamera4()
    {
        if (!isTweening)
        {
            camStartPos = transform.position;
            isTweening = true;
        }
        LeanTween.moveX(gameObject, transform.position.x - 0.7f, 0.04f);
        LeanTween.moveY(gameObject, transform.position.y - 0.4f, 0.1f).setOnComplete(ResetCamPos);
    }

    public void ResetCamPos()
    {
        LeanTween.move(gameObject, camStartPos, 0.1f);
        isTweening = false;
    }
}