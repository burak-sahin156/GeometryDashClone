using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GeometryDash.Inputs
{
    public class InputReader : IInputReader
    {
        public bool Hold => this._hold;
        public bool Click => this._click;
        public bool Canceled => this._canceled;

        private bool _click;
        private bool _hold;
        private bool _canceled;

        public void ReadInput()
        {
            _click = Input.GetMouseButtonDown(0);
            _hold = Input.GetMouseButton(0);
            _canceled = Input.GetMouseButtonUp(0);
        }
    }
}

