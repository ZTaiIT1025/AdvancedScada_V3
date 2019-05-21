using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace AdvancedScada.IBaseService.Common
{
    public class Functions
    {
        private static readonly object mutex = new object();
        private static Functions _instance;
        public static ChannelCount EventChannelCount;

        public static Functions GetFunctions()
        {
            lock (mutex)
            {
                if (_instance == null) _instance = new Functions();
            }

            return _instance;
        }
        public IGetServiceBase GetAssemblyService()
        {
            IGetServiceBase iServiceDriver = null;
            try
            {
                iServiceDriver = GetAssemblyService(@"\AdvancedScada.BaseService.dll",
                    "AdvancedScada.BaseService.ServiceBase");
            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }


            return iServiceDriver;
        }


        public IServiceDriver GetAssemblyDrivers(string Path, string NameSpaceAndClass)
        {
            IServiceDriver iServiceDriverAll = null;
            try
            {
#pragma warning disable IDE0043 // Invalid format string
                iServiceDriverAll = GetAssembly($@"\AdvancedScada.{Path}.Core.dll",
                    string.Format("AdvancedScada.{0}.Core.{1}Service", NameSpaceAndClass));
#pragma warning restore IDE0043 // Invalid format string
            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }

            return iServiceDriverAll;
        }

        public IServiceDriver GetAssembly(string Path, string NameSpaceAndClass)
        {
            IServiceDriver iServiceDriver = null;
            try
            {
                // قراءة مصفوفة  البايت الخاصة بالمشروع الثاني
                var buffer = Application.StartupPath + Path;

                // تحميل الملف
                var dll = Assembly.LoadFile(buffer);

                // تعريف متغير يعبر عن اسم الكلاس في المشروع الثاني شاملا الاسم الخاص بفضاء الأسماء الموجود بها الكلاس
                var dllName = NameSpaceAndClass;
                var t = dll.GetType(dllName);
                // أخيرا نحصل علي الواجهة كالتالي
                iServiceDriver = (IServiceDriver) Activator.CreateInstance(t);


            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }


            return iServiceDriver;
        }

        public IGetServiceBase GetAssemblyService(string Path, string NameSpaceAndClass)
        {
            IGetServiceBase iServiceDriver = null;
            try
            {
                // قراءة مصفوفة  البايت الخاصة بالمشروع الثاني
                var buffer = Application.StartupPath + Path;

                // تحميل الملف
                var dll = Assembly.LoadFile(buffer);

                // تعريف متغير يعبر عن اسم الكلاس في المشروع الثاني شاملا الاسم الخاص بفضاء الأسماء الموجود بها الكلاس
                var dllName = NameSpaceAndClass;
                var t = dll.GetType(dllName);
                // أخيرا نحصل علي الواجهة كالتالي
                iServiceDriver = (IGetServiceBase) Activator.CreateInstance(t);


            }
            catch (Exception ex)
            {
                var err = new HMIException.ScadaException(GetType().Name, ex.Message);
            }
            return iServiceDriver;

        }

        public static T CreateInstance<T>(params object[] Params) where T : class // params keyword for array
        {
            var argTypes = new List<Type>();

            //used .GetType() method to get the appropriate type
            //Param can be null so handle accordingly
            foreach (var Param in Params)
                argTypes.Add((Param ?? new object()).GetType());
            var Types = typeof(T).GetConstructors();
            foreach (var node in Types)
            {
                var Args = node.GetParameters();
                if (Params.Length == Args.Length)
                {
                    var cond = new bool[Params.Length];
                    //handle derived types
                    for (var i = 0; i < Params.Length; i++)
                        if (Args[i].ParameterType.IsAssignableFrom(argTypes[i]))
                            cond[i] = true;
                    if (cond[0] && cond[1])
                        return (T) node.Invoke(Params);
                }
            }
            return default(T);
        }
        public object ParseNamespace(string Path, string classname) //Looks up class in System.dll
        {
            var DotNetPath = Application.StartupPath + Path;
            var Asm = Assembly.LoadFile(DotNetPath);
            var Types = Asm.GetExportedTypes();
            foreach (var Node in Types)
                if (Node.Name == classname)
                    return Node;
            return null;
        }

        public object CreateInstance(Type pContext, object[] Params)
        {
            var argTypes = new List<Type>();

            //used .GetType() method to get the appropriate type
            //Param can be null so handle accordingly
            if (Params != null)
                foreach (var Param in Params)
                    if (Param != null)
                        argTypes.Add(Param.GetType());
                    else
                        argTypes.Add(null);

            var Types = pContext.GetConstructors();
            foreach (var node in Types)
            {
                var Args = node.GetParameters();
                // Params can be null for default constructors so use argTypes
                if (argTypes.Count == Args.Length)
                {
                    var areTypesCompatible = true;
                    for (var i = 0; i < Params.Length; i++)
                    {
                        if (argTypes[i] == null)
                        {
                            if (Args[i].ParameterType.IsValueType)
                            {
                                //fill the defaults for value type if not supplied
                                Params[i] = CreateInstance(Args[i].ParameterType, null);
                                argTypes[i] = Params[i].GetType();
                            }
                            else
                            {
                                argTypes[i] = Args[i].ParameterType;
                            }
                        }
                        if (!Args[i].ParameterType.IsAssignableFrom(argTypes[i]))
                        {
                            areTypesCompatible = false;
                            break;
                        }
                    }
                    if (areTypesCompatible)
                        return node.Invoke(Params);
                }
            }

            //delegate type to Activator.CreateInstance if unable to find a suitable constructor
            return Activator.CreateInstance(pContext);
        }
    }
}