using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImgURL : MonoBehaviour
{

    public Image image;
    public InputField _url;

    public void Buttonclick()
    {
        StartCoroutine(GetUrlImg(_url.text));
    }

    IEnumerator GetUrlImg(string x)
    {
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(x);
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.Log(req.error);
        }
        else
        {
            Texture2D img = ((DownloadHandlerTexture)req.downloadHandler).texture;
            image.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height),Vector2.zero);
        }
    }
}
