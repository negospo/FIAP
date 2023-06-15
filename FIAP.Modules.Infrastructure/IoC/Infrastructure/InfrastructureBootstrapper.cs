using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Modules.Infrastructure.IoC.Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            //services.AddScoped<ICustomerReadOnlyRepository, CustomerReadOnlyRepository>();
            //services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            //services.AddScoped<IKafkaAdapter, KafkaAdapterProducer>();
            //services.AddScoped<IServiceBusQueueProducer, ServiceBusQueueProducer>();
        }
    }
}
