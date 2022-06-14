using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform BG1, BG2;
    public float scrollSpeed;
    
    // How wide is the image
    private float bgWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Look at the BG1 SpriteRenderer and tells how wide the image is 
        bgWidth = BG1.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
      // Multiply Time.deltaTime for constant speed regardless of what PC you are running 
      BG1.position = new Vector3(BG1.position.x - (scrollSpeed * Time.deltaTime), BG1.position.y, BG2.position.z);
      BG2.position -= new Vector3(scrollSpeed * Time.deltaTime, 0f, 0f);

      // -bgWidth - 1 = 26
      if(BG1.position.x < -bgWidth - 1 )
      {
          // Move back over to the right
          BG1.position += new Vector3(bgWidth * 2f, 0f, 0f);
      }
      if(BG2.position.x < -bgWidth - 1 )
      {
          BG2.position += new Vector3(bgWidth * 2f, 0f, 0f);
      }
    }
}
