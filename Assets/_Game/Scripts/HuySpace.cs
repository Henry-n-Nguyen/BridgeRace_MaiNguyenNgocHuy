﻿using System.Collections;
using UnityEngine;

namespace HuySpace
{
    public enum MovementState
    {
        walking,
        air
    }

    public enum Direct
    {
        Forward,
        ForwardRight,
        Right,
        BackRight,
        Back,
        BackLeft,
        Left,
        ForwardLeft,
        None = -1
    }
}