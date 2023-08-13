using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDash.Inputs
{
    public interface IInputReader
    {
        bool Hold { get; }
        bool Click { get; }

        bool Canceled { get; }
        void ReadInput();
    }
}

