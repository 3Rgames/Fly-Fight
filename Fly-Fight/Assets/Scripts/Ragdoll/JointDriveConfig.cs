using System;
using UnityEngine;

internal class JointDriveConfig
{
    public int positionSpring { get; set; }
    public int positionDamper { get; set; }
    public int maximumForce { get; set; }

    public static implicit operator JointDrive(JointDriveConfig v)
    {
        throw new NotImplementedException();
    }
}