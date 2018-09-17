using System;
using System.Reflection;

namespace FirstNotebook.PubSub
{
    public class Subscription<Tmessage> : IDisposable
    {
        public readonly MethodInfo MethodInfo;
        public readonly WeakReference TargetObjet;
        public readonly bool IsStatic;

        private readonly EventAggregator _eventAggregator;
        private bool _isDisposed;

        public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
        {
            MethodInfo = action.Method;
            if (action.Target == null)
            {
                IsStatic = true;
            }

            TargetObjet = new WeakReference(action.Target);
            _eventAggregator = eventAggregator;
        }

        ~Subscription()
        {
            if (!_isDisposed)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _eventAggregator.UnSbscribe(this);
            _isDisposed = true;
        }

        public Action<Tmessage> CreatAction()
        {
            if (TargetObjet.Target != null && TargetObjet.IsAlive)
            {
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), TargetObjet.Target, MethodInfo);
            }

            if (IsStatic)
            {
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), MethodInfo);
            }

            return null;
        }
    }

}
