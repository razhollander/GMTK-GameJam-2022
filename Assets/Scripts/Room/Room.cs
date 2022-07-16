using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector2Int Id;
    public SpriteRenderer RoomSprite;
    // Start is called before the first frame update
    public RoomTemplate[] GetRoomTemplates()
    {
        return GetComponentsInChildren<RoomTemplate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
