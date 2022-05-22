using Autofac;
using Tringle.Core.Repositories;
using Tringle.Core.Services;
using Tringle.Repository;
using Tringle.Repository.Repositories;
using Tringle.Services.Service;

namespace Tringle.API.Modules
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(TringleRepository<>)).As(typeof(ITringleRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(TringleService<>)).As(typeof(ITringleService<>)).InstancePerLifetimeScope();

            builder.RegisterType<AccountRepository>().As(typeof(IAccountRepository)).InstancePerLifetimeScope();
            builder.RegisterType<AccountService>().As(typeof(IAccountService)).InstancePerLifetimeScope();

            builder.RegisterType<TransactionRepository>().As(typeof(ITransactionRepository)).InstancePerLifetimeScope();
            builder.RegisterType<TransactionService>().As(typeof(ITransactionService)).InstancePerLifetimeScope();

            builder.RegisterType<PaymentService>().As(typeof(IPaymentService)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(DataContext<>));

            base.Load(builder);
        }
    }
}
