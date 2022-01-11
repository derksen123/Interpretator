using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Pattern.NUnit.UI;

namespace Pattern.Interpreter.UnitTests
{
	// Этот класс отвечает за запуск пользовательского интерфейса
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// объявления уровня класса
		UIWindow window;
		TouchRunner runner;

		// Этот метод вызывается, когда приложение загружено и готово к запуску
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// создание новго экземпляра окна на основе размера экрана
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			runner = new TouchRunner (window);

			// регистрация тестов, заключенных в основное приложение
			runner.Add (System.Reflection.Assembly.GetExecutingAssembly ());

			window.RootViewController = new UINavigationController (runner.GetViewController ());
			
			// сделать окно видимым
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

