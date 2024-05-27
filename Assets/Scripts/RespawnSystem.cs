using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
  [SerializeField] Transform RespawnPoint;

    public Transform GetRespawnPoint() { return RespawnPoint; }
}
