using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour
{
    public List<Enemy> EnemiesCanBePlaced;
}

public enum Enemy
{
    Piranha,
    Guard,
    Camera,
    Spike,
    Dog
}
