using System;
using System.Reflection;

namespace FirstNotebook.PubSub
{
    public class Subscription<Tmessage> : IDisposable
    {
        private readonly WeakReference _targetObjet;
        private readonly bool _isStatic;
        private readonly MethodInfo _methodInfo;

        private readonly EventAggregator _eventAggregator;
        private bool _isDisposed;

        public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
        {
            _methodInfo = action.Method;
            if (action.Target == null)
            {
                _isStatic = true;
            }

            _targetObjet = new WeakReference(action.Target);
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
            _eventAggregator.UnSubscribe(this);
            _isDisposed = true;
        }

        public Action<Tmessage> CreateAction()
        {
            if (_targetObjet.Target != null && _targetObjet.IsAlive)
            {
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), _targetObjet.Target, _methodInfo);
            }

            if (_isStatic)
            {
                return (Action<Tmessage>)Delegate.CreateDelegate(typeof(Action<Tmessage>), _methodInfo);
            }

            return null;
        }
    }
}
