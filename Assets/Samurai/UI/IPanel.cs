using System;

namespace Samurai.UI
{
	public interface IPanel
	{
		void Show();
		void Hide();
		void Toggle();

		bool opened{ get; }
	}
}

