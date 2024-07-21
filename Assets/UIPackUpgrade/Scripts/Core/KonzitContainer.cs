using System;
using System.Collections.Generic;
using System.Linq;

namespace Konzit.Core.DI
{
    public class KonzitContainer
    {
        public static readonly Dictionary<Type, object> ModulesDict = new Dictionary<Type, object>();
        #region Add Module
        public static void AddModule<TInterface, TModule>()
        {
            AddModule(typeof(TInterface), typeof(TModule));
        }

        public static void SetModule<TInterface, TModule>()
        {
            SetModule(typeof(TInterface), typeof(TModule));
        }

        public static void SetModule<TInterface, TModule>(object view)
        {
            SetModule(typeof (TInterface), typeof(TModule), view);
        }

        public static void AddModule(Type tInterface, Type tModule)
        {
            
            if (!ModulesDict.ContainsKey(tInterface))
            {
                object instant = Activator.CreateInstance(tModule.GetType());
                var isImplement = tModule.GetType().Equals(tInterface.GetType());
                if (isImplement)
                {
                    
                    ModulesDict.Add(tInterface, instant);
                    return;
                }

                throw new Exception($"Module {tModule.Name} not implement from {tInterface.Name}");
            }
            else
                throw new Exception("Key has been contain!" + " with key name: " + tInterface.Name);

        }

        private static void SetModule(Type interfaceType, Type moduleType)
        {
            //Kiem tra module da implement interface chua
            if (!interfaceType.IsAssignableFrom(moduleType))
            {
                throw new Exception("Wrong Module type");
            }

            //Tim constructor dau tien
            var firstConstructor = moduleType.GetConstructors()[0];
            object module = null;
            //Neu nhu khong có tham so
            if (!firstConstructor.GetParameters().Any())
            {
                //Khoi tao module
                module = firstConstructor.Invoke(null); // new Database(), new Logger()
            }
            else
            {
                //Lay cac tham so của constructor
                var constructorParameters = firstConstructor.GetParameters(); //IDatebase, ILogger

                var moduleDependecies = new List<object>();
                foreach (var parameter in constructorParameters)
                {
                    var dependency = GetModule(parameter.ParameterType); //Lay module tuong ung tu DIContainer
                    moduleDependecies.Add(dependency);
                }

                //Inject cac dependency vao constructor cua module
                module = firstConstructor.Invoke(moduleDependecies.ToArray());
            }
            //Luu tru interface va module tuong ung
            ModulesDict.Add(interfaceType, module);
        }

        private static void SetModule(Type interfaceType, Type moduleType, object moduleView)
        {
            //Kiem tra module da implement interface chua
            if (!interfaceType.IsAssignableFrom(moduleType))
            {
                throw new Exception("Wrong Module type");
            }

            //Kiem tra view cua module da co trong dict chua, chua co thi add, phan nay se chinh lai sau
            if (!ModulesDict.ContainsKey(moduleView.GetType()))
            {
                ModulesDict.Add(moduleView.GetType(), moduleView);
            }

            //Tim constructor dau tien
            var firstConstructor = moduleType.GetConstructors()[0];
            object module = null;
            //Neu nhu khong có tham so
            if (!firstConstructor.GetParameters().Any())
            {
                //Khoi tao module
                module = firstConstructor.Invoke(null); // new Database(), new Logger()
            }
            else
            {
                //Lay cac tham so của constructor
                var constructorParameters = firstConstructor.GetParameters(); //IDatebase, ILogger

                var moduleDependecies = new List<object>();

                foreach (var parameter in constructorParameters)
                {
                    var dependency = GetModule(parameter.ParameterType); //Lay module tuong ung tu DIContainer
                    moduleDependecies.Add(dependency);
                }

                //Inject cac dependency vao constructor cua module
                module = firstConstructor.Invoke(moduleDependecies.ToArray());
            }
            //Luu tru interface va module tuong ung
            ModulesDict.Add(interfaceType, module);
        }
        #endregion

        #region Get Module
        public static T GetModule<T>()
        {
            return (T)GetModule(typeof(T));
        }

        public static object GetModule(Type type)
        {
            object module = ModulesDict[type];
            return module;
        }
        #endregion
    }

}
