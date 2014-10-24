using UnityEngine;
using System.Collections;

public class onClickStone : MonoBehaviour
{
	
		public int count = 1;
		float _width = 480f;
		float _height = 854f;

		// Use this for initialization
		void Start ()
		{
				float scaleX = Screen.width / _width;
				float scaleY = Screen.height / _height;

				GUIText[] texts = FindObjectsOfType (typeof(GUIText)) as GUIText[]; 
				foreach (GUIText myText in texts) { //find your element of text
			
						Vector2 pixOff = myText.pixelOffset; //your pixel offset on screen
						int origSizeText = myText.fontSize;
						myText.pixelOffset = new Vector2 (pixOff.x * scaleX, pixOff.y * scaleY); //new position
						float floatFontSize = origSizeText * scaleX; //new size font in a float
						myText.fontSize = (int)Mathf.RoundToInt (floatFontSize); // Closest value of fontSize
			
				}
		}

		void Awake ()
		{
				Application.targetFrameRate = 60;
		}
		// Update is called once per frame
		void Update ()
		{
				// обработка тача и апдейт count

				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
						//if (Input.GetMouseButtonDown (0)) {
						Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
						GUIText ThisText = GameObject.Find ("GUI Text").GetComponent<GUIText> ();
						RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
						//ThisText.text = ThisText.fontSize.ToString();
						if (hitInfo.collider != null) {
								count++;
								ThisText.text = "Score:" + count;
						}

				}
		}
		
		void OnGUI ()
		{
			
		}
}
