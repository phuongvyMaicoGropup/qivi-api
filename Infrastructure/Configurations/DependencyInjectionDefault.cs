//using System;
//namespace Infrastructure.Configurations
//{
//    public class DefaultDependencyResolver :
//    {
//        private IServiceProvider serviceProvider;
//        public DefaultDependencyResolver(IServiceProvider serviceProvider)
//        {
//            this.serviceProvider = serviceProvider;
//        }

//        public object GetService(Type serviceType)
//        {
//            return this.serviceProvider.GetService(serviceType);
//        }

//        public IEnumerable<object> GetServices(Type serviceType)
//        {
//            return this.serviceProvider.GetServices(serviceType);
//        }
//    }
//}

