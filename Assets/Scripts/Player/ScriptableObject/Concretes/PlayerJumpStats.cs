using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GeometryDash/Player/Stats/JumpStats", fileName = "New Jump Stats")]
public class PlayerJumpStats : PlayerStats
{
    public float JumpPower;
    public float RotateAngleSpeed;
    public LayerMask GroundLayer;
}
