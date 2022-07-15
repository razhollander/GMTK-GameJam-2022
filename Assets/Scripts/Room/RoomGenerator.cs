using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] private Room _room;
    [SerializeField] private Vector2Int _numOfRooms = new Vector2Int(3,3);
    
    [ContextMenu("Generate rooms")]
    public void GenerateRooms()
    {
        GameObject roomsParent = new GameObject("RoomsParent");
        
        var roomSize = _room.RoomSprite.bounds.size.x;

        for (int i = _numOfRooms.x-1; i >=0; i--)
        {
            for (int j = _numOfRooms.y-1; j >= 0 ; j--)
            {
                var room = Instantiate(_room.gameObject, roomsParent.transform);
                room.transform.localPosition = new Vector3(i * roomSize, j * roomSize);
            }
        }
    }
}
