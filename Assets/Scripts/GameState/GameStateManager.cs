using System;
using UnityEngine;

namespace GameState
{
    public class GameStateManager<T> : MonoBehaviour where T : Enum
    {
        public event Action<T> OnGameStateChanged;

        public T CurrentState { get; private set; }

        public virtual void SetCurrentState(T state)
        {
            if (!CurrentState.Equals(state))
            {
                CurrentState = state;
                OnGameStateChanged?.Invoke(CurrentState);
            }
        }
    }
}
