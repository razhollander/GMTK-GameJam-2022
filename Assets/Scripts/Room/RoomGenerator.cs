using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private Room _room;
    [SerializeField] private Vector2 _numOfRooms = new Vector2(3,3);
    
    [ContextMenu("Generate rooms")]
    public void GenerateRooms()
    {
        GameObject roomsParent = new GameObject("RoomsParent");
        
        var roomSize = _room.RoomSprite.size.x;

        for (int i = 0; i < _numOfRooms.x; i++)
        {
            for (int j = 0; j < _numOfRooms.y; j++)
            {
                Instantiate(_room.gameObject, roomsParent.transform);
                _room.transform.localPosition = new Vector3(i * roomSize, j * roomSize);
            }
        }
    }
}
