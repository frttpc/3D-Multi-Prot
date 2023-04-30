using System.Collections.Generic;
using UnityEngine;

namespace Frttpc
{
    [CreateAssetMenu(menuName = "Scriptable Objects /Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<IGameEventListener> eventListeners = new();

        public void Raise()
        {
            foreach (IGameEventListener listener in eventListeners)
            {
                listener.OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}