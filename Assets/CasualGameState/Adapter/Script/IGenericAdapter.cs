/* Author DevDaoSi
 * @2024
 * 
 * Adapter design pattern and using generic
 */

using UnityEngine;

namespace Konzit.Core.Adapter
{
    public interface IGenericAdapter<T>
    {
         T GetModule();
    }

    public class ServiceToAdapter<T> : IGenericAdapter<T>
    {
        private object _module;

        public ServiceToAdapter(T module)
        {
            _module = module;
        }

        public T GetModule()
        {
            try
            {
                T module = (T)_module;
                return module;

            }
            catch
            {
                Debug.Log($"<color=red>Error to parse module type to object type</color>");
                return default(T);
            }
        }
    }
}
