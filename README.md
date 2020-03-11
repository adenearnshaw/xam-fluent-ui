# Xamarin Forms Fluent UI

Here's a small sample app to demo Xamarin Forms 4.6 [Fluent UI](https://github.com/xamarin/Xamarin.Forms/pull/8342) syntax.

The project takes inspiration from Brandon Minnick's [XamConverter](https://github.com/brminnick/XamConverter) project, but adds in [Microsoft Extensions](https://github.com/dotnet/extensions) to allow Dependency Injection of services.

ViewModels are declared as a Type Parameter of each page, and the `BaseContentPage` uses the IServiceProvider, to new up an instance of the VM and set it as the Page's Binding Context.

The page's `OnAppearing` method, invokes a method in the ViewModel so that data fetching can be triggered post page-load.
