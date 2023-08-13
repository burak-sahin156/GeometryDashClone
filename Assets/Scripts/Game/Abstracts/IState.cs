using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometryDash.StateMachineSystem
{
    public interface IState
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
    }
}

