using System;
using System.Linq.Expressions;
using SimpleInjector;
using WpfDI.Model.Interface.Model;
using WpfDI.Model.Validator;
using WpfDI.View;
using WpfDI.ViewModel.Interface;
using WpfDI.ViewModel.ViewModels;

namespace WpfDI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            MapViews();
            var container = SetupContainer();
            var app = new App();
            var mainWindow = new MainWindow { DataContext = container.GetInstance<MainWindowViewModel>() };
            app.Run(mainWindow);
        }

        private static void MapViews()
        {
            ViewMapper.Register<MainWindow, MainWindowViewModel>();
            ViewMapper.Register<Text, TextViewModel>();
        }

        private static Container SetupContainer()
        {
            var container = new Container();
            container.Options.AllowResolvingFuncFactories();
            container.Register<MainWindowViewModel>();
            container.Register<TextViewModel>();
            container.Register<IINavigator, Navigator>();
            container.Register<IIAgencyValidator, AgencyValidator>();
            container.Register<IIAgencyDataAccess, Model.DataAccess.AgencyDataAccess>();
            container.RegisterDecorator<IIAgencyDataAccess, Model.Decorator.AgencyDecorator>();
            container.Verify();
            return container;
        }

        private static void AllowResolvingFuncFactories(this ContainerOptions options)
        {
            options.Container.ResolveUnregisteredType += (s, e) =>
            {
                var type = e.UnregisteredServiceType;

                if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Func<>))
                    return;

                var serviceType = type.GenericTypeArguments[0];

                var registration =
                    options.Container.GetRegistration(serviceType, true);

                var funcType = typeof(Func<>).MakeGenericType(serviceType);

                var factoryDelegate = Expression.Lambda(funcType,
                    registration.BuildExpression()).Compile();

                e.Register(Expression.Constant(factoryDelegate));
            };
        }
    }
}