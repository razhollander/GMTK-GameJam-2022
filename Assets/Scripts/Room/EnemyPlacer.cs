using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour
{
    public List<Enemy> _enemiesCanBePlaced;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Enemy
{
    Pirana,
    Gourd,
    Camera,
    Spike,
    Dog
}
