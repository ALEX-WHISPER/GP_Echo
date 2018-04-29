using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSourceImage : MonoBehaviour {
    public Image sourceImage;
    public Sprite[] srcImagesArray;

    void Update()
    {
        if(GetComponent<Image>().enabled == false)
        {
            GetComponent<Image>().enabled = true;
        }
        GetComponent<Image>().sprite = sourceImage.sprite;
    }

    public int GetSourceImageID()
    {
        for (int i = 0; i < srcImagesArray.Length; i++ )
        {
            if (GetComponent<Image>().sprite == srcImagesArray[i])
            {
                //Debug.Log(i);
                return i;
            }
        }
        return 0;
    }
}
