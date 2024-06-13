using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public Texture2D iagme;
	public Texture2D proccessiamge;
	// Use this for initialization
	void Start ()
	{
	proccessiamge=	CopyTexture2D (iagme);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//CopiedTexture is the original Texture  which you want to copy.
	public Texture2D CopyTexture2D(Texture2D copiedTexture)
	{
		//Create a new Texture2D, which will be the copy.
		Texture2D texture = new Texture2D(copiedTexture.width, copiedTexture.height);
		//Choose your filtermode and wrapmode here.
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;

		int y = 0;
		while (y < texture.height)
		{
			int x = 0;
			while (x < texture.width)
			{
				if(x>50)
				//INSERT YOUR LOGIC HERE
				
				{
					//This line of code and if statement, turn Green pixels into Red pixels.
					texture.SetPixel(x, y, Color.green);
				}
				else
				{
					//This line of code is REQUIRED. Do NOT delete it. This is what copies the image as it was, without any change.
					texture.SetPixel(x, y, copiedTexture.GetPixel(x,y));
				}
				++x;
			}
			++y;
		}
		//Name the texture, if you want.
		texture.name = ("_SpriteSheet");

		//This finalizes it. If you want to edit it still, do it before you finish with .Apply(). Do NOT expect to edit the image after you have applied. It did NOT work for me to edit it after this function.
		texture.Apply();

		//Return the variable, so you have it to assign to a permanent variable and so you can use it.
		return texture;
	}

}
