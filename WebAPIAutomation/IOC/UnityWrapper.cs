using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;

namespace WebAPIAutomation.IOC
{
    public class UnityWrapper
    {
        protected static IUnityContainer _container;
        protected static string ContainerName = "Automation";
        protected static string Unity = "unity";

        //Container getter setter
        public static IUnityContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }

        //static constructor
        static UnityWrapper()
        {
            if (_container == null)
            {
                Container = new UnityContainer();
            }
        }


        public static void LoadConfig()
        {


            _container.LoadConfiguration(ContainerName);
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection(Unity);
            section.Configure(Container, ContainerName);


        }


        /// <typeparam name="T">Type of object to return</typeparam>
        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        public static T Resolve<T>()
        {
            T result = default(T);
            if (Container.IsRegistered(typeof(T)))
            {
                result = Container.Resolve<T>();
            }
            return result;
        }
        /**************************************************/
        /**************************************************/
        /*******************/
        /***** RESOLVE *****/
        /*******************/
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <param name="name">Object to resolve</param>
        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        public static T Resolve<T>(string name)
        {
            T result = default(T);
            if (Container.IsRegistered<T>(name))
            {
                return Container.Resolve<T>(name);
            }
            return result;
        }
        /**************************************************/
        /**************************************************/
        /********************/
        /***** REGISTER *****/
        /********************/
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <param name="name">Object to resolve</param>
        /// <summary>
        /// Register the type parameter T.
        /// </summary>
        public static void Register<T>()
        {
            if (!Container.IsRegistered<T>())
            {
                Container.RegisterType<T>();
            }
        }
        /**************************************************/
        /**************************************************/
        /********************/
        /***** REGISTER *****/
        /********************/
        /// <typeparam name="TFrom">Type of object to return</typeparam>
        /// <summary>
        /// Register the type parameter T.
        /// </summary>
        public static void Register<TFrom, TTo>() where TTo : TFrom
        {
            if (!Container.IsRegistered<TFrom>())
            {
                Container.RegisterType<TFrom, TTo>();
            }
        }
        /**************************************************/
        /**************************************************/
        /********************/
        /***** REGISTER *****/
        /********************/
        /// <typeparam name="TFrom">Type of object to return</typeparam>
        /// <param name="name">Object to resolve</param>
        /// <summary>
        /// Register the type parameter T.
        /// </summary>
        public static void Register<TFrom, TTo>(string name) where TTo : TFrom
        {
            if (!Container.IsRegistered<TFrom>(name))
            {
                Container.RegisterType<TFrom, TTo>(name);
            }
        }
    }
}
