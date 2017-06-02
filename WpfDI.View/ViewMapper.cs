using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfDI.View
{
    public static class ViewMapper
    {
        private static Dictionary<Type, Type> Mapping { get; } = new Dictionary<Type, Type>();

        public static void Register<TView, TViewModel>()
        {
            Mapping.Add(typeof(TViewModel), typeof(TView));
        }

        public static object CreateView(object viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            if (!Mapping.TryGetValue(viewModel.GetType(), out var viewType))
            {
                throw new ArgumentException($"Could not find view for {viewModel.GetType().Name}.");
            }

            var view = (FrameworkElement) Activator.CreateInstance(viewType);
            view.DataContext = viewModel;
            return view;
        }
    }
}