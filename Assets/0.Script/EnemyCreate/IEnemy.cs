using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Create(GameObject obj, Transform parent);
    void Move();

}
